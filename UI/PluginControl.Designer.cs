namespace Dataverse.BulkImageUploader
{
    partial class PluginControl
    {
        private System.ComponentModel.IContainer components = null;

        // Header Panel & Connection Labels
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.Label lblEnvUrl;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblOrgName;
        private System.Windows.Forms.Button btnLoadTables;

        // Configuration Panel Controls
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label lblImageCol;
        private System.Windows.Forms.ComboBox cmbImageColumns;
        private System.Windows.Forms.Label lblMapField;
        private System.Windows.Forms.ComboBox cmbMappingFields;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnBrowseFolder;

        // Checkboxes & Settings Controls
        private System.Windows.Forms.CheckBox chkCaseInsensitive;
        private System.Windows.Forms.CheckBox chkIgnoreSpaces;
        private System.Windows.Forms.CheckBox chkIgnoreUnderscores;
        private System.Windows.Forms.CheckBox chkIgnoreHyphens;
        private System.Windows.Forms.CheckBox chkTrimSpaces;
        private System.Windows.Forms.CheckBox chkNormalizeText;
        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.NumericUpDown numBatchSize;

        // Action Buttons
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.Button btnCancel;

        // Summary Cards
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTotal;
        private System.Windows.Forms.Label lblSummaryMatched;
        private System.Windows.Forms.Label lblSummaryDuplicates;
        private System.Windows.Forms.Label lblSummaryNoMatch;

        // DataGrid & Progress
        private System.Windows.Forms.DataGridView gridPreview;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblEnvName = new System.Windows.Forms.Label();
            this.lblEnvUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblOrgName = new System.Windows.Forms.Label();
            this.btnLoadTables = new System.Windows.Forms.Button();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.lblTable = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.lblImageCol = new System.Windows.Forms.Label();
            this.cmbImageColumns = new System.Windows.Forms.ComboBox();
            this.lblMapField = new System.Windows.Forms.Label();
            this.cmbMappingFields = new System.Windows.Forms.ComboBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.chkCaseInsensitive = new System.Windows.Forms.CheckBox();
            this.chkIgnoreSpaces = new System.Windows.Forms.CheckBox();
            this.chkIgnoreUnderscores = new System.Windows.Forms.CheckBox();
            this.chkIgnoreHyphens = new System.Windows.Forms.CheckBox();
            this.chkTrimSpaces = new System.Windows.Forms.CheckBox();
            this.chkNormalizeText = new System.Windows.Forms.CheckBox();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.numBatchSize = new System.Windows.Forms.NumericUpDown();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummaryTotal = new System.Windows.Forms.Label();
            this.lblSummaryMatched = new System.Windows.Forms.Label();
            this.lblSummaryDuplicates = new System.Windows.Forms.Label();
            this.lblSummaryNoMatch = new System.Windows.Forms.Label();
            this.gridPreview = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlHeader.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).BeginInit();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblEnvName);
            this.pnlHeader.Controls.Add(this.lblEnvUrl);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.lblOrgName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 174);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(814, 33);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(3, 3);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(171, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Bulk Image Uploader";
            // 
            // lblEnvName
            // 
            this.lblEnvName.AutoSize = true;
            this.lblEnvName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEnvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEnvName.Location = new System.Drawing.Point(190, 8);
            this.lblEnvName.Name = "lblEnvName";
            this.lblEnvName.Size = new System.Drawing.Size(88, 15);
            this.lblEnvName.TabIndex = 1;
            this.lblEnvName.Text = "Not Connected";
            // 
            // lblEnvUrl
            // 
            this.lblEnvUrl.AutoSize = true;
            this.lblEnvUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEnvUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEnvUrl.Location = new System.Drawing.Point(377, 8);
            this.lblEnvUrl.Name = "lblEnvUrl";
            this.lblEnvUrl.Size = new System.Drawing.Size(12, 15);
            this.lblEnvUrl.TabIndex = 2;
            this.lblEnvUrl.Text = "-";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(0, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 20);
            this.lblUserName.TabIndex = 3;
            // 
            // lblOrgName
            // 
            this.lblOrgName.Location = new System.Drawing.Point(0, 0);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(86, 20);
            this.lblOrgName.TabIndex = 4;
            // 
            // btnLoadTables
            // 
            this.btnLoadTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLoadTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTables.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoadTables.ForeColor = System.Drawing.Color.White;
            this.btnLoadTables.Location = new System.Drawing.Point(694, 95);
            this.btnLoadTables.Name = "btnLoadTables";
            this.btnLoadTables.Size = new System.Drawing.Size(107, 30);
            this.btnLoadTables.TabIndex = 1;
            this.btnLoadTables.Text = "Load Entities";
            this.btnLoadTables.UseVisualStyleBackColor = false;
            this.btnLoadTables.Click += new System.EventHandler(this.btnLoadTables_Click);
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlConfig.Controls.Add(this.lblTable);
            this.pnlConfig.Controls.Add(this.cmbTables);
            this.pnlConfig.Controls.Add(this.lblImageCol);
            this.pnlConfig.Controls.Add(this.cmbImageColumns);
            this.pnlConfig.Controls.Add(this.lblMapField);
            this.pnlConfig.Controls.Add(this.btnLoadTables);
            this.pnlConfig.Controls.Add(this.cmbMappingFields);
            this.pnlConfig.Controls.Add(this.lblFolder);
            this.pnlConfig.Controls.Add(this.txtFolderPath);
            this.pnlConfig.Controls.Add(this.btnBrowseFolder);
            this.pnlConfig.Controls.Add(this.chkCaseInsensitive);
            this.pnlConfig.Controls.Add(this.chkIgnoreSpaces);
            this.pnlConfig.Controls.Add(this.chkIgnoreUnderscores);
            this.pnlConfig.Controls.Add(this.chkIgnoreHyphens);
            this.pnlConfig.Controls.Add(this.chkTrimSpaces);
            this.pnlConfig.Controls.Add(this.chkNormalizeText);
            this.pnlConfig.Controls.Add(this.lblBatchSize);
            this.pnlConfig.Controls.Add(this.numBatchSize);
            this.pnlConfig.Controls.Add(this.btnPreview);
            this.pnlConfig.Controls.Add(this.btnStartUpload);
            this.pnlConfig.Controls.Add(this.btnCancel);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Location = new System.Drawing.Point(0, 35);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(814, 139);
            this.pnlConfig.TabIndex = 1;
            // 
            // lblTable
            // 
            this.lblTable.Location = new System.Drawing.Point(10, 10);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(77, 13);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Target Entity:";
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.Location = new System.Drawing.Point(10, 26);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(189, 21);
            this.cmbTables.TabIndex = 1;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // lblImageCol
            // 
            this.lblImageCol.Location = new System.Drawing.Point(210, 10);
            this.lblImageCol.Name = "lblImageCol";
            this.lblImageCol.Size = new System.Drawing.Size(77, 13);
            this.lblImageCol.TabIndex = 2;
            this.lblImageCol.Text = "Image Column:";
            // 
            // cmbImageColumns
            // 
            this.cmbImageColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageColumns.Location = new System.Drawing.Point(210, 26);
            this.cmbImageColumns.Name = "cmbImageColumns";
            this.cmbImageColumns.Size = new System.Drawing.Size(155, 21);
            this.cmbImageColumns.TabIndex = 3;
            // 
            // lblMapField
            // 
            this.lblMapField.Location = new System.Drawing.Point(377, 10);
            this.lblMapField.Name = "lblMapField";
            this.lblMapField.Size = new System.Drawing.Size(94, 13);
            this.lblMapField.TabIndex = 4;
            this.lblMapField.Text = "Filename Match:";
            // 
            // cmbMappingFields
            // 
            this.cmbMappingFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMappingFields.Location = new System.Drawing.Point(377, 26);
            this.cmbMappingFields.Name = "cmbMappingFields";
            this.cmbMappingFields.Size = new System.Drawing.Size(155, 21);
            this.cmbMappingFields.TabIndex = 5;
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(544, 10);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(69, 13);
            this.lblFolder.TabIndex = 6;
            this.lblFolder.Text = "Image Folder:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(544, 26);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(189, 20);
            this.txtFolderPath.TabIndex = 7;
            this.txtFolderPath.Text = "C:BulkImages";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(737, 25);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(64, 22);
            this.btnBrowseFolder.TabIndex = 8;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // chkCaseInsensitive
            // 
            this.chkCaseInsensitive.Checked = true;
            this.chkCaseInsensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseInsensitive.Location = new System.Drawing.Point(10, 56);
            this.chkCaseInsensitive.Name = "chkCaseInsensitive";
            this.chkCaseInsensitive.Size = new System.Drawing.Size(103, 17);
            this.chkCaseInsensitive.TabIndex = 9;
            this.chkCaseInsensitive.Text = "Case Insensitive";
            // 
            // chkIgnoreSpaces
            // 
            this.chkIgnoreSpaces.Location = new System.Drawing.Point(113, 57);
            this.chkIgnoreSpaces.Name = "chkIgnoreSpaces";
            this.chkIgnoreSpaces.Size = new System.Drawing.Size(99, 17);
            this.chkIgnoreSpaces.TabIndex = 10;
            this.chkIgnoreSpaces.Text = "Ignore Spaces";
            // 
            // chkIgnoreUnderscores
            // 
            this.chkIgnoreUnderscores.Location = new System.Drawing.Point(212, 57);
            this.chkIgnoreUnderscores.Name = "chkIgnoreUnderscores";
            this.chkIgnoreUnderscores.Size = new System.Drawing.Size(140, 17);
            this.chkIgnoreUnderscores.TabIndex = 11;
            this.chkIgnoreUnderscores.Text = "Ignore Underscores";
            // 
            // chkIgnoreHyphens
            // 
            this.chkIgnoreHyphens.Location = new System.Drawing.Point(353, 56);
            this.chkIgnoreHyphens.Name = "chkIgnoreHyphens";
            this.chkIgnoreHyphens.Size = new System.Drawing.Size(123, 20);
            this.chkIgnoreHyphens.TabIndex = 12;
            this.chkIgnoreHyphens.Text = "Ignore Hyphens";
            // 
            // chkTrimSpaces
            // 
            this.chkTrimSpaces.Checked = true;
            this.chkTrimSpaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrimSpaces.Location = new System.Drawing.Point(479, 57);
            this.chkTrimSpaces.Name = "chkTrimSpaces";
            this.chkTrimSpaces.Size = new System.Drawing.Size(77, 17);
            this.chkTrimSpaces.TabIndex = 13;
            this.chkTrimSpaces.Text = "Trim Spaces";
            // 
            // chkNormalizeText
            // 
            this.chkNormalizeText.Location = new System.Drawing.Point(557, 58);
            this.chkNormalizeText.Name = "chkNormalizeText";
            this.chkNormalizeText.Size = new System.Drawing.Size(116, 15);
            this.chkNormalizeText.TabIndex = 14;
            this.chkNormalizeText.Text = "Normalize Text";
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.Location = new System.Drawing.Point(678, 60);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(56, 13);
            this.lblBatchSize.TabIndex = 15;
            this.lblBatchSize.Text = "Batch Size:";
            // 
            // numBatchSize
            // 
            this.numBatchSize.Location = new System.Drawing.Point(737, 55);
            this.numBatchSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBatchSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchSize.Name = "numBatchSize";
            this.numBatchSize.Size = new System.Drawing.Size(51, 20);
            this.numBatchSize.TabIndex = 16;
            this.numBatchSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(10, 95);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(120, 30);
            this.btnPreview.TabIndex = 18;
            this.btnPreview.Text = "1. Preview Match";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnStartUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStartUpload.ForeColor = System.Drawing.Color.White;
            this.btnStartUpload.Location = new System.Drawing.Point(141, 95);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(137, 30);
            this.btnStartUpload.TabIndex = 19;
            this.btnStartUpload.Text = "2. Start Bulk Upload";
            this.btnStartUpload.UseVisualStyleBackColor = false;
            this.btnStartUpload.Click += new System.EventHandler(this.btnStartUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(287, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlSummary.Controls.Add(this.lblSummaryTotal);
            this.pnlSummary.Controls.Add(this.lblSummaryMatched);
            this.pnlSummary.Controls.Add(this.lblSummaryDuplicates);
            this.pnlSummary.Controls.Add(this.lblSummaryNoMatch);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 0);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(814, 35);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblSummaryTotal
            // 
            this.lblSummaryTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTotal.Location = new System.Drawing.Point(10, 10);
            this.lblSummaryTotal.Name = "lblSummaryTotal";
            this.lblSummaryTotal.Size = new System.Drawing.Size(129, 17);
            this.lblSummaryTotal.TabIndex = 0;
            this.lblSummaryTotal.Text = "Total Files: 0";
            // 
            // lblSummaryMatched
            // 
            this.lblSummaryMatched.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryMatched.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.lblSummaryMatched.Location = new System.Drawing.Point(154, 10);
            this.lblSummaryMatched.Name = "lblSummaryMatched";
            this.lblSummaryMatched.Size = new System.Drawing.Size(129, 17);
            this.lblSummaryMatched.TabIndex = 1;
            this.lblSummaryMatched.Text = "Matched: 0";
            // 
            // lblSummaryDuplicates
            // 
            this.lblSummaryDuplicates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryDuplicates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.lblSummaryDuplicates.Location = new System.Drawing.Point(300, 10);
            this.lblSummaryDuplicates.Name = "lblSummaryDuplicates";
            this.lblSummaryDuplicates.Size = new System.Drawing.Size(129, 17);
            this.lblSummaryDuplicates.TabIndex = 2;
            this.lblSummaryDuplicates.Text = "Duplicates: 0";
            // 
            // lblSummaryNoMatch
            // 
            this.lblSummaryNoMatch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryNoMatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblSummaryNoMatch.Location = new System.Drawing.Point(446, 10);
            this.lblSummaryNoMatch.Name = "lblSummaryNoMatch";
            this.lblSummaryNoMatch.Size = new System.Drawing.Size(129, 17);
            this.lblSummaryNoMatch.TabIndex = 3;
            this.lblSummaryNoMatch.Text = "No Match: 0";
            // 
            // gridPreview
            // 
            this.gridPreview.AllowUserToAddRows = false;
            this.gridPreview.AllowUserToDeleteRows = false;
            this.gridPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPreview.BackgroundColor = System.Drawing.Color.White;
            this.gridPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPreview.Location = new System.Drawing.Point(0, 0);
            this.gridPreview.Name = "gridPreview";
            this.gridPreview.ReadOnly = true;
            this.gridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPreview.Size = new System.Drawing.Size(814, 563);
            this.gridPreview.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBottom.Controls.Add(this.lblProgressStatus);
            this.pnlBottom.Controls.Add(this.progressBar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 520);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(814, 43);
            this.pnlBottom.TabIndex = 4;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Location = new System.Drawing.Point(0, 0);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(86, 20);
            this.lblProgressStatus.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(86, 20);
            this.progressBar.TabIndex = 1;
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.gridPreview);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(814, 563);
            this.Load += new System.EventHandler(this.PluginControl_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}