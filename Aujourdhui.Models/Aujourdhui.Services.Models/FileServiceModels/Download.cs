using System.IO;

#nullable enable

namespace Aujourdhui.Services.Models.FileServiceModels
{
    public class Download
    {
        public Stream? Stream { get; set; }
        public string? ContentType { get; set; }

        public Download() { }
        public Download(Stream stream, string contentType)
        {
            Stream = stream;
            ContentType = contentType;
        }
    }
}
