using Aujourdhui.Services.Models.FileServiceModels;
using Aujourdhui.Services.Models.ImageServiceModels;
using System;
using System.Threading.Tasks;

namespace Aujourdhui.Infrastructure.Services
{
    public interface IImageService : IFileService
    {
        Task<Download> DownloadAsync(Guid guid, ImageSize size = ImageSize.Origin, ImageProportion proportion = ImageProportion.Origin);
        Task<Download> DownloadAsync(string entity, int objectId, DateTime? date = null, ImageSize size = ImageSize.Origin, ImageProportion proportion = ImageProportion.Origin);
    }
}
