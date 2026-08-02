using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using Dataverse.BulkImageUploader.Models;
using Dataverse.BulkImageUploader.Services;
using Dataverse.BulkImageUploader.Settings;

namespace Dataverse.BulkImageUploader
{
    public partial class PluginControl : PluginControlBase
    {
        private DataverseService _dataverseService;
        private MetadataService _metadataService;
        private MappingEngine _mappingEngine;
        private ImageProcessor _imageProcessor;
        private UploadEngine _uploadEngine;
        private PluginSettings _settings;

        private List<ImageMappingItem> _mappingItems = new List<ImageMappingItem>();
        private CancellationTokenSource _cts;

        public PluginControl()
        {
            InitializeComponent();
        }

        private void PluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Initializing Bulk Image Uploader Plugin...", new Uri("https://github.com/"));
            LoadSettings();
            ValidateConnection();
        }

        private void ValidateConnection()
        {
            if (Service != null && ConnectionDetail != null)
            {
                lblEnvName.Text = ConnectionDetail.ConnectionName;
                lblEnvUrl.Text = ConnectionDetail.WebApplicationUrl;
                lblUserName.Text = ConnectionDetail.UserName;
                lblOrgName.Text = ConnectionDetail.Organization;

                _dataverseService = new DataverseService(Service, msg=> LogInfo(msg));
                _metadataService = new MetadataService(Service);
                _mappingEngine = new MappingEngine();
                _imageProcessor = new ImageProcessor();
                _uploadEngine = new UploadEngine(_dataverseService, msg => LogInfo(msg));

                btnLoadTables.Enabled = true;
            }
            else
            {
                lblEnvName.Text = "Not Connected";
                lblEnvUrl.Text = "Please connect to Dataverse using XrmToolBox";
                lblUserName.Text = "-";
                lblOrgName.Text = "-";
                btnLoadTables.Enabled = false;
            }
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            
            if (detail != null)
            {
                lblEnvName.Text = detail.ConnectionName;
                lblEnvUrl.Text = detail.WebApplicationUrl;
                lblUserName.Text = detail.UserName;
                lblOrgName.Text = detail.Organization;
                
                _dataverseService = new DataverseService(Service, msg => LogInfo(msg));
                _metadataService = new MetadataService(Service);
                _mappingEngine = new MappingEngine();
                _imageProcessor = new ImageProcessor();
                _uploadEngine = new UploadEngine(_dataverseService, msg => LogInfo(msg));

                btnLoadTables.Enabled = true;
                LogInfo($"Connected to Dataverse: {detail.WebApplicationUrl} as {detail.UserName}");
            }
        }

        private async void btnLoadTables_Click(object sender, EventArgs e)
        {
            ExecuteMethod(async () =>
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Retrieving Dataverse entities with Image columns...",
                    Work = (worker, args) =>
                    {
                        args.Result = _metadataService.RetrieveImageCapableEntities();
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            LogError($"Error retrieving entities: {args.Error.Message}");
                            MessageBox.Show(args.Error.Message, "Metadata Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var entities = (List<EntityMetadataInfo>)args.Result;
                        cmbTables.DataSource = entities;
                        cmbTables.DisplayMember = "DisplayNameWithLogical";
                        cmbTables.ValueMember = "LogicalName";
                        LogInfo($"Successfully loaded {entities.Count} Image-capable tables.");
                    }
                });
            });
        }

        private async void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedItem == null || cmbImageColumns.SelectedItem == null || cmbMappingFields.SelectedItem == null)
            {
                MessageBox.Show("Please select a Table, Image Column, and Mapping Field first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Scanning files and matching against Dataverse records...",
                Work = (worker, args) =>
                {
                    var selectedTable = (EntityMetadataInfo)cmbTables.SelectedItem;
                    var selectedImageCol = (string)cmbImageColumns.SelectedValue;
                    var selectedMappingField = (string)cmbMappingFields.SelectedValue;

                    // 1. Fetch records
                    var records = _dataverseService.RetrieveRecordsForMapping(selectedTable.LogicalName, selectedMappingField, selectedImageCol);

                    // 2. Scan local files
                    var files = Directory.GetFiles(txtFolderPath.Text, "*.*", SearchOption.TopDirectoryOnly)
                                         .Where(f => IsSupportedImageFormat(f))
                                         .ToList();

                    // 3. Auto Map
                    var options = GetNormalizationOptions();
                    var mapped = _mappingEngine.ExecuteMapping(files, records, selectedMappingField, options);
                    args.Result = mapped;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        LogError($"Preview failed: {args.Error.Message}");
                        return;
                    }

                    _mappingItems = (List<ImageMappingItem>)args.Result;
                    gridPreview.DataSource = _mappingItems;
                    UpdateSummaryCards();
                    LogInfo($"Preview generated: {_mappingItems.Count(x => x.Status == MappingStatus.Matched)} matched successfully.");
                }
            });
        }

        private void UpdateSummaryCards()
        {
            if (_mappingItems == null) return;
            int total = _mappingItems.Count;
            int matched = _mappingItems.Count(x => x.Status == MappingStatus.Matched);
            int duplicates = _mappingItems.Count(x => x.Status == MappingStatus.Duplicate);
            int noMatch = _mappingItems.Count(x => x.Status == MappingStatus.NoMatch);

            if (lblSummaryTotal != null) lblSummaryTotal.Text = total.ToString();
            if (lblSummaryMatched != null) lblSummaryMatched.Text = matched.ToString();
            if (lblSummaryDuplicates != null) lblSummaryDuplicates.Text = duplicates.ToString();
            if (lblSummaryNoMatch != null) lblSummaryNoMatch.Text = noMatch.ToString();
        }

        private async void btnStartUpload_Click(object sender, EventArgs e)
        {
            var matchedItems = _mappingItems.Where(i => i.Status == MappingStatus.Matched || i.Status == MappingStatus.ExistingImage).ToList();
            if (!matchedItems.Any())
            {
                MessageBox.Show("No matched records ready to upload.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _cts = new CancellationTokenSource();
            btnStartUpload.Enabled = false;
            btnCancel.Enabled = true;

            var progress = new Progress<UploadProgressState>(ReportProgress);
            var selectedTable = (EntityMetadataInfo)cmbTables.SelectedItem;
            var selectedImageCol = (string)cmbImageColumns.SelectedValue;

            try
            {
                var summary = await _uploadEngine.ProcessUploadAsync(
                    matchedItems,
                    selectedTable.LogicalName,
                    selectedImageCol,
                    _settings.BatchSize,
                    _settings.ResizeBeforeUpload,
                    _settings.MaxResizeWidth,
                    progress,
                    _cts.Token
                );

                MessageBox.Show($"Upload Complete! Succeeded: {summary.Succeeded}, Failed: {summary.Failed}", "Upload Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                LogInfo("Upload process was cancelled by user.");
            }
            finally
            {
                btnStartUpload.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void ReportProgress(UploadProgressState state)
        {
            progressBar.Value = state.PercentComplete;
            lblProgressStatus.Text = $"Processed {state.Processed} of {state.Total} ({state.SpeedFilesPerSec:F1} files/sec) - ETA: {state.EstimatedRemainingTime}";
        }

        private NormalizationOptions GetNormalizationOptions()
        {
            return new NormalizationOptions
            {
                CaseInsensitive = chkCaseInsensitive.Checked,
                IgnoreSpaces = chkIgnoreSpaces.Checked,
                IgnoreUnderscores = chkIgnoreUnderscores.Checked,
                IgnoreHyphens = chkIgnoreHyphens.Checked,
                TrimSpaces = chkTrimSpaces.Checked,
                NormalizeText = chkNormalizeText.Checked
            };
        }

        private bool IsSupportedImageFormat(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLower();
            return new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" }.Contains(ext);
        }

        private void LoadSettings()
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out _settings))
            {
                numBatchSize.Value = _settings.BatchSize;
                chkOverwrite.Checked = _settings.OverwriteExisting;
            }
            else
            {
                _settings = new PluginSettings();
            }
        }
    }
} 