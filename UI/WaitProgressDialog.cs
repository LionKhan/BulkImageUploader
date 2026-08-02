using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Dataverse.BulkImageUploader.Models;

namespace Dataverse.BulkImageUploader.UI
{
    /// <summary>
    /// Dedicated WinForms Progress Dialog Modal for 150,000+ Record Bulk Uploads.
    /// Locks UI and provides thread-safe real-time throughput metrics, ETA countdown, and pause/cancel controls.
    /// </summary>
    public partial class WaitProgressDialog : Form
    {
        private readonly CancellationTokenSource _cts;
        private readonly Stopwatch _stopwatch;
        private bool _isPaused = false;
        private int _totalRecords = 150000;

        public bool IsCancelled => _cts.IsCancellationRequested;
        public bool IsPaused => _isPaused;

        public WaitProgressDialog(int totalRecords, CancellationTokenSource cts)
        {
            InitializeComponent();
            _totalRecords = totalRecords;
            _cts = cts;
            _stopwatch = Stopwatch.StartNew();
            
            progressBar.Maximum = Math.Max(1, totalRecords);
            lblTotalCount.Text = totalRecords.ToString("N0");
            lblProcessedCount.Text = "0";
            lblSuccessCount.Text = "0";
            lblFailedCount.Text = "0";
            lblSpeed.Text = "0 items/sec";
            lblETA.Text = "Calculating...";
        }

        public void UpdateProgress(UploadProgressState state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<UploadProgressState>(UpdateProgress), state);
                return;
            }

            int val = Math.Min(state.Processed, progressBar.Maximum);
            progressBar.Value = val;

            lblProcessedCount.Text = state.Processed.ToString("N0");
            lblSuccessCount.Text = state.Succeeded.ToString("N0");
            lblFailedCount.Text = state.Failed.ToString("N0");
            lblPercent.Text = $"{state.PercentComplete}%";

            double elapsedSecs = _stopwatch.Elapsed.TotalSeconds;
            double speed = elapsedSecs > 0 ? state.Processed / elapsedSecs : 0;
            lblSpeed.Text = $"{speed:F1} uploads/sec";

            if (speed > 0)
            {
                int remainingItems = state.Total - state.Processed;
                double remainingSecs = remainingItems / speed;
                TimeSpan eta = TimeSpan.FromSeconds(remainingSecs);
                lblETA.Text = eta.Hours > 0 
                    ? $"{eta.Hours:D2}h {eta.Minutes:D2}m {eta.Seconds:D2}s"
                    : $"{eta.Minutes:D2}m {eta.Seconds:D2}s";
            }

            lblCurrentFile.Text = $"Processing file: {state.CurrentFileName}";
        }

        public void AppendLog(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(AppendLog), message);
                return;
            }

            txtLogStream.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLogStream.SelectionStart = txtLogStream.Text.Length;
            txtLogStream.ScrollToCaret();
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPaused;
            btnPauseResume.Text = _isPaused ? "▶ Resume Upload" : "⏸ Pause Upload";
            btnPauseResume.BackColor = _isPaused ? Color.FromArgb(40, 167, 69) : Color.FromArgb(255, 193, 7);
            AppendLog(_isPaused ? "Upload process paused by user." : "Resuming upload process...");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show(
                "Are you sure you want to cancel the 150,000+ batch upload process?",
                "Cancel Bulk Upload",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                _cts.Cancel();
                btnCancel.Enabled = false;
                btnCancel.Text = "Cancelling...";
                AppendLog("Cancellation requested. Gracefully stopping worker threads...");
            }
        }
    }
}