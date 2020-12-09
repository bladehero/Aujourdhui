﻿using Aujourdhui.Services.Models.ImageServiceModels;
using System.Collections.Generic;
using System.IO;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using System.Drawing.Imaging;
using System.Drawing;

namespace Aujourdhui.Infrastructure.Services
{
    public interface IImageFormatterService
    {
        LinkedList<ImageProportion> Proportions { get; }
        ProportionServiceResolver ProportionServiceResolver { get; }
        LinkedList<ImageSize> Sizes { get; }

        bool CanBeProcessed(Stream source, ImageSize size, ImageProportion proportion);
        Stream ProcessImage(Stream source, ImageSize size, ImageProportion proportion);
        string SpecifyImagePath(string path, ImageSize size, ImageProportion proportion);
    }
}
