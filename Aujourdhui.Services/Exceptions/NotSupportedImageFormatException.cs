using System;

#nullable enable 

namespace Aujourdhui.Services.Exceptions
{
    public class NotSupportedImageFormatException : Exception
    {
        public string Extension { get; set; }

        public NotSupportedImageFormatException(string extension)
            : this(extension, null) { }
        public NotSupportedImageFormatException(string extension, Exception? innerException)
            : base($"Not supported image format `{extension}`!", innerException)
        {
            Extension = extension;
        }
    }
}
