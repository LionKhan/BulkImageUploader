namespace Dataverse.BulkImageUploader
{
    partial class PluginControl
    {
        private System.ComponentModel.IContainer components = null;

        // Connection & Environment Labels
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.Label lblEnvUrl;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblOrgName;

        // Summary Card Labels
        private System.Windows.Forms.Label lblSummaryTotal;
        private System.Windows.Forms.Label lblSummaryMatched;
        private System.Windows.Forms.Label lblSummaryDuplicates;
        private System.Windows.Forms.Label lblSummaryNoMatch;

        // Dropdowns & TextBoxes
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.ComboBox cmbImageColumns;
        private System.Windows.Forms.ComboBox cmbMappingFields;
        private System.Windows.Forms.TextBox txtFolderPath;

        // Checkboxes & Settings Controls
        private System.Windows.Forms.CheckBox chkCaseInsensitive;
        private System.Windows.Forms.CheckBox chkIgnoreSpaces;
        private System.Windows.Forms.CheckBox chkIgnoreUnderscores;
        private System.Windows.Forms.CheckBox chkIgnoreHyphens;
        private System.Windows.Forms.CheckBox chkTrimSpaces;
        private System.Windows.Forms.CheckBox chkNormalizeText;
        private System.Windows.Forms.NumericUpDown numBatchSize;
        private System.Windows.Forms.CheckBox chkOverwrite;

        // Action Buttons
        private System.Windows.Forms.Button btnLoadTables;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.Button btnCancel;

        // Progress Controls & DataGrid
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.DataGridView gridPreview;

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
            this.lblEnvName = new System.Windows.Forms.Label();
            this.lblEnvUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblOrgName = new System.Windows.Forms.Label();

            this.lblSummaryTotal = new System.Windows.Forms.Label();
            this.lblSummaryMatched = new System.Windows.Forms.Label();
            this.lblSummaryDuplicates = new System.Windows.Forms.Label();
            this.lblSummaryNoMatch = new System.Windows.Forms.Label();

            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.cmbImageColumns = new System.Windows.Forms.ComboBox();
            this.cmbMappingFields = new System.Windows.Forms.ComboBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();

            this.chkCaseInsensitive = new System.Windows.Forms.CheckBox();
            this.chkIgnoreSpaces = new System.Windows.Forms.CheckBox();
            this.chkIgnoreUnderscores = new System.Windows.Forms.CheckBox();
            this.chkIgnoreHyphens = new System.Windows.Forms.CheckBox();
            this.chkTrimSpaces = new System.Windows.Forms.CheckBox();
            this.chkNormalizeText = new System.Windows.Forms.CheckBox();
            this.numBatchSize = new System.Windows.Forms.NumericUpDown();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();

            this.btnLoadTables = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.gridPreview = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            this.SuspendLayout();

            // Default Designer Initializations
            this.chkCaseInsensitive.Checked = true;
            this.chkTrimSpaces.Checked = true;
            this.numBatchSize.Value = new decimal(new int[] { 100, 0, 0, 0 });
            this.txtFolderPath.Text = @"C:BulkImages";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(950, 650);

            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            this.ResumeLayout(false);
        }
    }
}