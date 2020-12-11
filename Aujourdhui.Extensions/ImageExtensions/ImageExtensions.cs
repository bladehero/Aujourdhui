using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Aujourdhui.Extensions.ImageExtensions
{
    public static class ImageExtensions
    {
        public static bool IsCorrectImageFormat(this Image image, IEnumerable<ImageFormat> imageFormats) => 
            imageFormats.Any(format => image.RawFormat.Equals(format));
    }
}
