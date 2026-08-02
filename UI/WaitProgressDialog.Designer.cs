namespace Dataverse.BulkImageUploader.UI
{
    partial class WaitProgressDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblProcessedCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblSuccessCount;
        private System.Windows.Forms.Label lblFailedCount;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblETA;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.TextBox txtLogStream;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel headerPanel;

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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblProcessedCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblSuccessCount = new System.Windows.Forms.Label();
            this.lblFailedCount = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblETA = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.txtLogStream = new System.Windows.Forms.TextBox();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form Properties
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk Upload in Progress (150,000+ Record Processing)";

            // Header Panel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 70;

            this.lblHeaderTitle.Text = "⚡ Dataverse 150,000+ Bulk Image Upload Engine";
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHeaderTitle.AutoSize = true;

            this.lblSubTitle.Text = "Processing multithreaded ExecuteMultiple payloads with automatic Service Protection retry...";
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(220, 235, 252);
            this.lblSubTitle.Location = new System.Drawing.Point(15, 38);
            this.lblSubTitle.AutoSize = true;

            this.headerPanel.Controls.Add(this.lblHeaderTitle);
            this.headerPanel.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.headerPanel);
        }
    }
}