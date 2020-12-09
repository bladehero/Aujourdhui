using Aujourdhui.Extensions.EnumExtensions;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.Drawing;

#nullable enable

namespace Aujourdhui.Services.ContentServices.ImageFormatters
{
    public class SquareProportionFormatter : IProportionFormatter
    {
        public ImageProportion Proportion => ImageProportion.Square;

        public Image PrepareImage(Func<Image, Size, Bitmap> resizing, Image image, ImageSize size)
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
            if (rate is null)
            {
                rate = Math.Min(image.Width, image.Height);
            }

            return resizing(image, new Size(rate.Value, rate.Value));
        }
    }
}
