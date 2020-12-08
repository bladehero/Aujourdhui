using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.Drawing;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class NotSupportedImageSizeException : Exception
    {
        public Image Image { get; set; }
        public ImageSize Size { get; set; }

        public NotSupportedImageSizeException(Image image, ImageSize size)
            : this(image, size, null) { }
        public NotSupportedImageSizeException(Image image, ImageSize size, Exception? innerException)
            : base($"Provided `{nameof(image)}` with size: `{image.Size}` cannot be resized to upper resolution with {nameof(size)}: `{size}`!", innerException)
        {
            Image = image;
            Size = size;
        }
    }
}
