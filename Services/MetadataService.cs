using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Dataverse.BulkImageUploader.Models;

namespace Dataverse.BulkImageUploader.Services
{
    public class MetadataService
    {
        private readonly IOrganizationService _service;
        private static Dictionary<string, EntityMetadata> _metadataCache = new Dictionary<string, EntityMetadata>();

        public MetadataService(IOrganizationService service)
        {
            _service = service;
        }

        public List<EntityMetadataInfo> RetrieveImageCapableEntities()
        {
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Attributes,
                RetrieveAsIfPublished = true
            };

            var response = (RetrieveAllEntitiesResponse)_service.Execute(request);
            var imageCapable = new List<EntityMetadataInfo>();

            foreach (var metadata in response.EntityMetadata)
            {
                if ( metadata.Attributes != null)
                {
                    var imageAttrs = metadata.Attributes.OfType<ImageAttributeMetadata>().ToList();
                    if (imageAttrs.Any())
                    {
                        imageCapable.Add(new EntityMetadataInfo
                        {
                            LogicalName = metadata.LogicalName,
                            DisplayName = metadata.DisplayName?.UserLocalizedLabel?.Label ?? metadata.LogicalName,
                            PrimaryIdAttribute = metadata.PrimaryIdAttribute,
                            PrimaryNameAttribute = metadata.PrimaryNameAttribute,
                            ImageAttributes = imageAttrs.Select(a => a.LogicalName).ToList()
                        });
                        
                        _metadataCache[metadata.LogicalName] = metadata;
                    }
                }
            }

            return imageCapable.OrderBy(e => e.DisplayName).ToList();
        }

        public List<AttributeMetadataInfo> GetImageAttributes(string entityLogicalName)
        {
            if (_metadataCache.TryGetValue(entityLogicalName, out var metadata))
            {
                return metadata.Attributes
                    .OfType<ImageAttributeMetadata>()
                    .Select(a => new AttributeMetadataInfo
                    {
                        LogicalName = a.LogicalName,
                        DisplayName = a.DisplayName?.UserLocalizedLabel?.Label ?? a.LogicalName,
                        IsPrimaryImage = a.IsPrimaryImage ?? false
                    }).ToList();
            }
            return new List<AttributeMetadataInfo>();
        }
    }
}