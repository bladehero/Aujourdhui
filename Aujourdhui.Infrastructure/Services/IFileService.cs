using Aujourdhui.Services.Models.FileServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aujourdhui.Infrastructure.Services
{
    public interface IFileService
    {
        Task<int> CountAsync(string entity, int objectId, DateTime? date = null);
        Task DeleteAllAsync(string entity, int objectId);
        Task DeleteAsync(Guid guid);
        Task<Download> DownloadAsync(Guid guid);
        Task<Download> DownloadAsync(string entity, int objectId, DateTime? date = null);
        Task<IEnumerable<Guid>> GetAsync(string entity, int objectId, DateTime? date = null, int? size = null, int page = 0);
        Task<Guid?> GetFirstAsync(string entity, int objectId, DateTime? date = null);
        Task<bool> HasMultipleAsync(string entity, int objectId, DateTime? date = null);
        Task<bool> OverwriteAsync(FileStreamSM model, Guid guid);
        Task<bool> UploadAsync(FileStreamSM model, string entity, int objectId, DateTime? date = null);
        Task<bool> UploadAsync(IEnumerable<FileStreamSM> models, string entity, int objectId, DateTime? date = null);
    }
}
