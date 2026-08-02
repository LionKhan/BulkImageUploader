using System;

namespace Dataverse.BulkImageUploader.Settings
{
    public class PluginSettings
    {
        public string LastSelectedTable { get; set; }
        public string LastImageColumn { get; set; }
        public string LastMappingField { get; set; }
        public string LastFolderPath { get; set; }
        public int BatchSize { get; set; } = 100;
        public bool OverwriteExisting { get; set; } = false;
        public bool SkipExisting { get; set; } = true;
        public bool CaseInsensitive { get; set; } = true;
        public bool IgnoreSpaces { get; set; } = false;
        public bool IgnoreUnderscores { get; set; } = false;
        public bool IgnoreHyphens { get; set; } = false;
        public bool TrimSpaces { get; set; } = true;
        public bool NormalizeText { get; set; } = false;
        public bool DryRunMode { get; set; } = false;
        public bool ResizeBeforeUpload { get; set; } = false;
        public int MaxResizeWidth { get; set; } = 2048;
        public bool CompressBeforeUpload { get; set; } = false;
        public double CompressQuality { get; set; } = 0.85;
    }
}