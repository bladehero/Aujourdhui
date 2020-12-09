using Aujourdhui.Services.Models.ImageServiceModels;
using System.Collections.Generic;
using System.IO;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using System.Drawing;

namespace Aujourdhui.Infrastructure.Services
{
    public interface IImageFormatterService
    {
        LinkedList<ImageProportion> Proportions { get; }
        ProportionServiceResolver ProportionServiceResolver { get; }
        LinkedList<ImageSize> Sizes { get; }

        bool CanBeProcessed(Image image, ImageSize size, ImageProportion proportion);
        Image ProcessImage(Image image, ImageSize size, ImageProportion proportion);
        string SpecifyImagePath(string path, ImageSize size, ImageProportion proportion);
    }
}
