using System.IO;

#nullable enable

namespace Aujourdhui.Services.Models.FileServiceModels
{
    public class FileStreamSM
    {
        public Stream? Stream { get; set; }
        public string? FileName { get; set; }

        public FileStreamSM() { }
        public FileStreamSM(Stream stream, string fileName)
        {
            Stream = stream;
            FileName = fileName;
        }
    }
}
