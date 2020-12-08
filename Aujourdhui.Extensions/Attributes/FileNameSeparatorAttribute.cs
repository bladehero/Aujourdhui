using System;

namespace Aujourdhui.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FileNameSeparatorAttribute : Attribute
    {
        public string Separator { get; set; }

        public FileNameSeparatorAttribute()
        {
            Separator = string.Empty;
        }
        public FileNameSeparatorAttribute(string separator)
        {
            Separator = separator;
        }
    }
}