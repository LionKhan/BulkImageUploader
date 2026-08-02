using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Dataverse.BulkImageUploader.Services
{
    /// <summary>
    /// Enterprise Image Processing Engine for Dataverse EntityImage Attributes.
    /// Handles image format validation, aspect-ratio resizing, and JPEG compression streams.
    /// </summary>
    public class ImageProcessor
    {
        public bool IsValidImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return false;

            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    return img.Width > 0 && img.Height > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public byte[] ProcessImage(string filePath, bool resize, int maxWidth, bool compress, double quality)
        {
            byte[] originalBytes = File.ReadAllBytes(filePath);
            if (!resize && !compress)
                return originalBytes;

            using (var msInput = new MemoryStream(originalBytes))
            using (var originalImg = Image.FromStream(msInput))
            {
                int newWidth = originalImg.Width;
                int newHeight = originalImg.Height;

                if (resize && originalImg.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)((double)originalImg.Height / originalImg.Width * maxWidth);
                }

                using (var resizedBitmap = new Bitmap(newWidth, newHeight))
                {
                    using (var g = Graphics.FromImage(resizedBitmap))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(originalImg, 0, 0, newWidth, newHeight);
                    }

                    using (var msOutput = new MemoryStream())
                    {
                        if (compress)
                        {
                            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            Encoder myEncoder = Encoder.Quality;
                            EncoderParameters myEncoderParameters = new EncoderParameters(1);
                            long qual = (long)(quality * 100);
                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, qual);
                            myEncoderParameters.Param[0] = myEncoderParameter;

                            resizedBitmap.Save(msOutput, jpgEncoder, myEncoderParameters);
                        }
                        else
                        {
                            resizedBitmap.Save(msOutput, originalImg.RawFormat.Guid == Guid.Empty ? ImageFormat.Jpeg : originalImg.RawFormat);
                        }
                        return msOutput.ToArray();
                    }
                }
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}