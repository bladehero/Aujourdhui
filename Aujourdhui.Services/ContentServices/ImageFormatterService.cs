using Aujourdhui.Data;
using Aujourdhui.Extensions.EnumExtensions;
using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Services.Models.ImageServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Aujourdhui.Services.ContentServices
{
    public class ImageFormatterService : BaseService<ImageFormatterService>, IImageFormatterService
    {
        public LinkedList<ImageSize> Sizes { get; } = EnumExtensions.ToLinkedList<ImageSize>();
        public LinkedList<ImageProportion> Proportions { get; } = EnumExtensions.ToLinkedList<ImageProportion>();
        public ProportionServiceResolver ProportionServiceResolver { get; }

        public ImageFormatterService(ILogger<ImageFormatterService> logger,
                                     IHttpContextAccessor httpContext,
                                     ApplicationDbContext applicationDbContext,
                                     ProportionServiceResolver proportionServiceResolver)
            : base(logger, httpContext, applicationDbContext)
        {
            ProportionServiceResolver = proportionServiceResolver;
        }

        public bool CanBeProcessed(Stream source, ImageSize size, ImageProportion proportion)
        {
            var formatter = ProportionServiceResolver(proportion);
            if (formatter is null)
            {
                throw new NotSupportedException($"Formatter of `{nameof(proportion)}` is not supported yet!");
            }

            var image = Image.FromStream(source);
            return formatter.CanBeFormatted(image, size);
        }

        public Stream ProcessImage(Stream source, ImageSize size, ImageProportion proportion)
        {
            if (!Sizes.Contains(size))
            {
                throw new ArgumentException($"Parameter `{nameof(size)}` is not supported at the moment!");
            }

            if (!Proportions.Contains(proportion))
            {
                throw new ArgumentException($"Parameter `{nameof(size)}` is not supported at the moment!");
            }

            var formatter = ProportionServiceResolver(proportion);
            if (formatter is null)
            {
                throw new NotSupportedException($"Formatter of `{nameof(proportion)}` is not supported yet!");
            }

            if (size == ImageSize.Origin && proportion == ImageProportion.Origin)
            {
                return source;
            }

            var image = Image.FromStream(source);
            try
            {
                var stream = formatter.PrepareImage(ResizeImage, image, size);
                return stream;
            }
            catch (NotSupportedImageSizeException ex)
            {
                Logger.LogError(ex,
                                "An exception ocurred in {0} while processing image for different sizes!",
                                GetFullMemberName());
            }
            return null;
        }

        public string SpecifyImagePath(string path, ImageSize size, ImageProportion proportion) =>
            Path.Combine(Path.GetDirectoryName(path) ?? string.Empty,
                         $"{size.GetDescription()}{size.GetFileNameSeparator()}" +
                         $"{proportion.GetDescription()}{proportion.GetFileNameSeparator()}" +
                         $"{Path.GetFileName(path)}");

        #region Helpers
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="size">Size values to resize to.</param>
        /// <returns>The resized image.</returns>
        protected static Bitmap ResizeImage(Image image, Size size)
        {
            return ResizeImage(image, size.Width, size.Height);
        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        protected static Bitmap ResizeImage(Image image, int width, int height)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;

            var hRatio = (float)originalHeight / height;
            var wRatio = (float)originalWidth / width;

            var ratio = Math.Min(hRatio, wRatio);

            var hScale = Convert.ToInt32(height * ratio);
            var wScale = Convert.ToInt32(width * ratio);

            var startX = (originalWidth - wScale) / 2;
            var startY = (originalHeight - hScale) / 2;

            var sourceRectangle = new Rectangle(startX, startY, wScale, hScale);

            var bitmap = new Bitmap(width, height);

            var destinationRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }

            return bitmap;
        }
        /// <summary>
        /// Resize the image using stream to the specified width and height.
        /// </summary>
        /// <param name="stream">The stream of an image to resize.</param>
        /// <param name="size">Size values to resize to.</param>
        /// <returns>The resized image.</returns>
        protected static Bitmap ResizeImage(Stream stream, Size size)
        {
            return ResizeImage(stream, size.Width, size.Height);
        }
        /// <summary>
        /// Resize the image using stream to the specified width and height.
        /// </summary>
        /// <param name="stream">The stream of an image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        protected static Bitmap ResizeImage(Stream stream, int width, int height)
        {
            var image = Image.FromStream(stream);
            return ResizeImage(image, width, height);
        }
        #endregion
    }
}
