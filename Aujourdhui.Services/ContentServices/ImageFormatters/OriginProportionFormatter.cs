using Aujourdhui.Extensions.EnumExtensions;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Aujourdhui.Services.ContentServices.ImageFormatters
{
    public class OriginProportionFormatter : IProportionFormatter
    {
        public ImageProportion Proportion => ImageProportion.Origin;

        public Stream PrepareImage(Func<Image, Size, Bitmap> resizing, Image image, ImageSize size)
        {
            if (resizing is null)
            {
                throw new NullReferenceException($"Parameter `{nameof(resizing)}` cannot be null!");
            }

            if (image is null)
            {
                throw new NullReferenceException($"Parameter `{nameof(image)}` cannot be null!");
            }

            if (((IProportionFormatter)this).CanBeFormatted(image, size) == false)
            {
                throw new NotSupportedImageSizeException(image, size);
            }

            var rate = size.GetImageSizeRate();

            var imageSize = rate is null 
                ? new Size(image.Width, image.Height) 
                : image.Width > image.Height 
                    ? new Size(rate.Value, (int)((decimal)image.Height / image.Width * rate.Value))
                    : new Size((int)((decimal)image.Width / image.Height * rate.Value), rate.Value);

            var bitmap = resizing(image, imageSize);
            var memoryStream = new MemoryStream();
            try
            {
                bitmap.Save(memoryStream, image.RawFormat);
            }
            catch (ExternalException ex)
            {
                throw new NotSupportedImageSizeException(image, size, ex);
            }
            return memoryStream;
        }
    }
}
