using Aujourdhui.Extensions.Attributes;
using System.ComponentModel;

namespace Aujourdhui.Services.Models.ImageServiceModels
{
    public enum ImageSize
    {
        [Description("")]
        Origin,
        [Description("XS")]
        [FileNameSeparator("_")]
        [ImageSizeRateAttribute(64)]
        ExtraSmall,
        [Description("SM")]
        [FileNameSeparator("_")]
        [ImageSizeRateAttribute(128)]
        Small,
        [Description("MD")]
        [FileNameSeparator("_")]
        [ImageSizeRateAttribute(256)]
        Medium,
        [Description("LG")]
        [FileNameSeparator("_")]
        [ImageSizeRateAttribute(1024)]
        Large,
        [Description("XL")]
        [FileNameSeparator("_")]
        [ImageSizeRateAttribute(2048)]
        ExtraLarge,
    }
}
