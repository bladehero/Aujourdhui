using System;

#nullable enable

namespace Aujourdhui.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ImageSizeRateAttribute : Attribute
    {
        public int? Rate { get; set; }

        public ImageSizeRateAttribute() { }
        public ImageSizeRateAttribute(int rate)
        {
            Rate = rate;
        }
    }
}
