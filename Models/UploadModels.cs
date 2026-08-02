using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;

namespace Dataverse.BulkImageUploader.Models
{
    public enum MappingStatus
    {
        Ready,
        Matched,
        Duplicate,
        NoMatch,
        InvalidImage,
        ExistingImage,
        Skipped,
        Uploaded,
        Failed
    }

    public class ImageMappingItem
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ExtractedMappingValue { get; set; }
        public MappingStatus Status { get; set; }
        public Entity MatchingRecord { get; set; }
        public List<Entity> DuplicateRecords { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class NormalizationOptions
    {
        public bool CaseInsensitive { get; set; } = true;
        public bool IgnoreSpaces { get; set; }
        public bool IgnoreUnderscores { get; set; }
        public bool IgnoreHyphens { get; set; }
        public bool TrimSpaces { get; set; } = true;
        public bool NormalizeText { get; set; }
    }

    public class EntityMetadataInfo
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public string PrimaryIdAttribute { get; set; }
        public string PrimaryNameAttribute { get; set; }
        public List<string> ImageAttributes { get; set; }

        public string DisplayNameWithLogical => $"{DisplayName} ({LogicalName})";
    }

    public class AttributeMetadataInfo
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public bool IsPrimaryImage { get; set; }
    }

    public class UploadProgressState
    {
        public int Total { get; set; }
        public int Processed { get; set; }
        public int PercentComplete { get; set; }
        public double SpeedFilesPerSec { get; set; }
        public string EstimatedRemainingTime { get; set; }
        public int Succeeded { get; set; }
        public int Failed { get; set; }
        public string CurrentFileName { get; set; }
    }

    public class UploadSummaryResult
    {
        public int Total;
        public int Succeeded;
        public int Failed;
        public int Skipped;
        public TimeSpan Duration;
    }
}