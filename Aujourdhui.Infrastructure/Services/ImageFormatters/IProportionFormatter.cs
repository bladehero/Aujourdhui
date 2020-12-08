using Aujourdhui.Extensions.EnumExtensions;
using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.Drawing;
using System.IO;

namespace Aujourdhui.Infrastructure.Services.ImageFormatters
{
    public interface IProportionFormatter
    {
        public ImageProportion Proportion { get; }
        bool CanBeFormatted(Image image, ImageSize size)
        {
            var rate = size.GetImageSizeRate();
            return Math.Max(image.Width, image.Height) > rate.GetValueOrDefault();
        }
        Stream PrepareImage(Func<Image, Size, Bitmap> resizing, Image image, ImageSize size);
    }
}
