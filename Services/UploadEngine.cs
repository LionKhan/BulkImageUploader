using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Messages;
using Dataverse.BulkImageUploader.Models;

namespace Dataverse.BulkImageUploader.Services
{
    public class UploadEngine
    {
        private readonly DataverseService _dataverseService;
        private readonly Action<string> _logger;

        public UploadEngine(DataverseService dataverseService, Action<string> logger)
        {
            _dataverseService = dataverseService;
            _logger = logger;
        }

        public async Task<UploadSummaryResult> ProcessUploadAsync(
            List<ImageMappingItem> items,
            string entityName,
            string imageColumnName,
            int batchSize,
            bool resizeBeforeUpload,
            int maxResizeWidth,
            IProgress<UploadProgressState> progress,
            CancellationToken token)
        {
            var summary = new UploadSummaryResult { Total = items.Count };
            var sw = Stopwatch.StartNew();
            int processed = 0;

            for (int i = 0; i < items.Count; i += batchSize)
            {
                token.ThrowIfCancellationRequested();

                var batch = items.Skip(i).Take(batchSize).ToList();
                var tasks = batch.Select(async item =>
                {
                    try
                    {
                        //byte[] imageBytes = await File.ReadAllBytesAsync(item.FilePath, token);

                        byte[] imageBytes = await Task.Run(() => File.ReadAllBytes(item.FilePath), token);
                        await _dataverseService.UploadImageRecordAsync(
                            entityName,
                            item.MatchingRecord.Id,
                            imageColumnName,
                            imageBytes,
                            token
                        );

                        item.Status = MappingStatus.Uploaded;
                        Interlocked.Increment(ref summary.Succeeded);
                    }
                    catch (Exception ex)
                    {
                        item.Status = MappingStatus.Failed;
                        item.ErrorMessage = ex.Message;
                        Interlocked.Increment(ref summary.Failed);
                        _logger?.Invoke($"Failed uploading {item.FileName}: {ex.Message}");
                    }
                    finally
                    {
                        Interlocked.Increment(ref processed);
                    }
                });

                await Task.WhenAll(tasks);

                double speed = processed / Math.Max(1, sw.Elapsed.TotalSeconds);
                double remainingSecs = (items.Count - processed) / Math.Max(0.1, speed);

                progress?.Report(new UploadProgressState
                {
                    Total = items.Count,
                    Processed = processed,
                    PercentComplete = (int)((processed / (double)items.Count) * 100),
                    SpeedFilesPerSec = speed,
                    EstimatedRemainingTime = TimeSpan.FromSeconds(remainingSecs).ToString("mm':'ss")
                });
            }

            summary.Duration = sw.Elapsed;
            return summary;
        }
    }
}