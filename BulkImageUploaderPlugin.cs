using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using System.ComponentModel.Composition;

namespace Dataverse.BulkImageUploader
{
    [Export(typeof(IXrmToolBoxPlugin)),
     ExportMetadata("Name", "Dataverse Bulk Image Uploader"),
     ExportMetadata("Description", "Enterprise bulk upload tool for Dataverse Image columns with filename auto-mapping, normalization, validation, and multi-threaded throughput."),
     ExportMetadata("BigImageBase64", ""), // Add base64 icon
     ExportMetadata("SmallImageBase64", ""),
     ExportMetadata("BackgroundColor", "#0F172A"),
     ExportMetadata("PrimaryFontColor", "#FFFFFF"),
     ExportMetadata("SecondaryFontColor", "#94A3B8")]
    public class BulkImageUploaderPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PluginControl();
        }
    }
}