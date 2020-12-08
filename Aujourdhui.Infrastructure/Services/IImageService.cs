using Aujourdhui.Services.Models.FileServiceModels;
using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Aujourdhui.Infrastructure.Services
{
    public interface IImageService : IFileService
    {
        Task<Stream> DownloadAsync(Guid guid, ImageSize size = ImageSize.Origin, ImageProportion proportion = ImageProportion.Origin);
        Task<Stream> DownloadAsync(string entity, int objectId, DateTime? date = null, ImageSize size = ImageSize.Origin, ImageProportion proportion = ImageProportion.Origin);
    }
}
