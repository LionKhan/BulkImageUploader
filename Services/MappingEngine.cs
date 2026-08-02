using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Xrm.Sdk;
using Dataverse.BulkImageUploader.Models;

namespace Dataverse.BulkImageUploader.Services
{
    public class MappingEngine
    {
        public List<ImageMappingItem> ExecuteMapping(
            List<string> filePaths,
            List<Entity> records,
            string mappingField,
            NormalizationOptions options)
        {
            var lookupMap = new Dictionary<string, List<Entity>>();

            // 1. Build Index
            foreach (var record in records)
            {
                if (record.Contains(mappingField) && record[mappingField] != null)
                {
                    var rawVal = record[mappingField].ToString();
                    var normalizedKey = Normalize(rawVal, options);

                    if (!lookupMap.ContainsKey(normalizedKey))
                    {
                        lookupMap[normalizedKey] = new List<Entity>();
                    }
                    lookupMap[normalizedKey].Add(record);
                }
            }

            // 2. Map Files
            var result = new List<ImageMappingItem>();
            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var rawValue = Path.GetFileNameWithoutExtension(filePath);
                var normalizedFileKey = Normalize(rawValue, options);

                var item = new ImageMappingItem
                {
                    FilePath = filePath,
                    FileName = fileName,
                    ExtractedMappingValue = rawValue,
                    FileSize = new FileInfo(filePath).Length
                };

                if (lookupMap.TryGetValue(normalizedFileKey, out var matchedRecords))
                {
                    if (matchedRecords.Count == 1)
                    {
                        item.MatchingRecord = matchedRecords[0];
                        item.Status = MappingStatus.Matched;
                    }
                    else
                    {
                        item.MatchingRecord = matchedRecords[0];
                        item.DuplicateRecords = matchedRecords;
                        item.Status = MappingStatus.Duplicate;
                        item.ErrorMessage = $"Multiple records matched key: {normalizedFileKey}";
                    }
                }
                else
                {
                    item.Status = MappingStatus.NoMatch;
                    item.ErrorMessage = "No Dataverse record found.";
                }

                result.Add(item);
            }

            return result;
        }

        public string Normalize(string input, NormalizationOptions options)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var val = input;
            if (options.TrimSpaces) val = val.Trim();
            if (options.CaseInsensitive) val = val.ToLowerInvariant();
            if (options.IgnoreSpaces) val = val.Replace(" ", "");
            if (options.IgnoreUnderscores) val = val.Replace("_", "");
            if (options.IgnoreHyphens) val = val.Replace("-", "");

            if (options.NormalizeText)
            {
                val = Regex.Replace(val, @"[^a-zA-Z0-9@.]", "");
            }

            return val;
        }
    }
}