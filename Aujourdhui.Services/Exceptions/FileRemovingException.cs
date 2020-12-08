using Aujourdhui.Data.Models;
using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class FileRemovingException : Exception
    {
        public string Path { get; set; }
        public FileReference FileReference { get; set; }

        public FileRemovingException(string path, FileReference fileReference)
            : this(path, fileReference, null) { }
        public FileRemovingException(string path, FileReference fileReference, Exception? innerException)
            : base($"File reference can't be deleted!{(innerException is null ? string.Empty : " See inner exception.")}", innerException)
        {
            Path = path;
            FileReference = fileReference;
        }
    }
}
