using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;

namespace Dataverse.BulkImageUploader.Services
{
    public class DataverseService
    {
        private readonly IOrganizationService _service;
        private readonly Action<string> _logger;

        public DataverseService(IOrganizationService service, Action<string> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger;
        }

        public List<Entity> RetrieveRecordsForMapping(string entityName, string mappingFieldName, string imageColumnName)
        {
            var query = new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(mappingFieldName, imageColumnName),
                PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1
                }
            };

            var allRecords = new List<Entity>();
            EntityCollection result;

            do
            {
                result = _service.RetrieveMultiple(query);
                allRecords.AddRange(result.Entities);
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = result.PagingCookie;
            } while (result.MoreRecords);

            return allRecords;
        }

        //public async Task<bool> UploadImageRecordAsync(string entityName, Guid recordId, string imageColumnName, byte[] imageBytes, CancellationToken cancellationToken)
        //{
        //    return await Task.Run(() =>
        //    {
        //        try
        //        {
        //            cancellationToken.ThrowIfCancellationRequested();

        //            var updateEntity = new Entity(entityName, recordId);
        //            updateEntity[imageColumnName] = imageBytes;

        //            _service.Update(updateEntity);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger?.Invoke($"Error updating record {recordId}: {ex.Message}");
        //            throw;
        //        }
        //    }, cancellationToken);
        //}
        public  bool UploadImageRecordsync(string entityName, Guid recordId, string imageColumnName, byte[] imageBytes, CancellationToken cancellationToken)
        {
           
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var updateEntity = new Entity(entityName, recordId);
                    updateEntity[imageColumnName] = imageBytes;

                    _service.Update(updateEntity);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger?.Invoke($"Error updating record {recordId}: {ex.Message}");
                    throw;
                }
            }
        
        public async Task<ExecuteMultipleResponse> ExecuteBatchUploadAsync(ExecuteMultipleRequest batchRequest, CancellationToken token)
        {
            return await Task.Run(() =>
            {
                try
                {
                    token.ThrowIfCancellationRequested();
                    return (ExecuteMultipleResponse)_service.Execute(batchRequest);
                }
                catch (Exception ex)
                {
                    _logger?.Invoke($"Batch execution failure: {ex.Message}");
                    throw;
                }
            }, token);
        }
    }
}