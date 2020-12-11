using Aujourdhui.Data;
using Aujourdhui.Data.Models;
using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Interfaces;
using Aujourdhui.Extensions.EntityFrameworkExtensions;
using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Services.Models.FileServiceModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace Aujourdhui.Services.ContentServices
{
    public class FileService : BaseService<FileService>, IFileService
    {
        public const string FolderName = "Storage";
        protected IWebHostEnvironment WebHostEnvironment { get; }
        protected virtual string Root => Path.Combine(WebHostEnvironment.ContentRootPath, FolderName);

        public FileService(ILogger<FileService> logger,
                            IHttpContextAccessor httpContext,
                            ApplicationDbContext applicationDbContext,
                            IWebHostEnvironment webHostEnvironment)
            : base(logger, httpContext, applicationDbContext)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public virtual async Task OverwriteAsync(FileStreamSM model, Guid guid)
        {
            var fileReference = await ApplicationDbContext.FileReferences.FirstOrDefaultAsync(x => x.Guid == guid);
            if (fileReference is null)
            {
                throw new FileReferenceNotFound(guid);
            }

            if (model is null)
            {
                throw new NullReferenceException($"`Parameter {nameof(model)}` cannot be null!");
            }

            if (string.IsNullOrWhiteSpace(model.FileName))
            {
                throw new ArgumentException(nameof(model.FileName));
            }

            if (model.Stream is null)
            {
                throw new NullReferenceException($"`Parameter {nameof(model.Stream)}` cannot be null!");
            }

            var folder = PathToFolderWithFile(fileReference.Entity, fileReference.Date, fileReference.Guid);
            Directory.Delete(folder, true);
            Directory.CreateDirectory(folder);
            var path = PathToFile(folder, model.FileName);

            var uploadTask = UploadFileAsync(model.Stream, path);

            fileReference.Name = model.FileName;
            ApplicationDbContext.FileReferences.Update(fileReference);
            var saveTask = ApplicationDbContext.SaveChangesAsync();

            try
            {
                await Task.WhenAll(uploadTask, saveTask);
            }
            catch (NotSupportedImageFormatException ex)
            {
                Logger.LogError(ex,
                                "An error occured in {0} while executing tasks: {1}, {2}",
                                GetFullMemberName(),
                                nameof(uploadTask),
                                nameof(saveTask));
                throw;
            }
        }
        public virtual async Task UploadAsync(FileStreamSM model, string entity, Guid guid, DateTime? date = null)
        {
            if (model is null)
            {
                throw new NullReferenceException($"`Parameter {nameof(model)}` cannot be null!");
            }

            if (string.IsNullOrWhiteSpace(model.FileName))
            {
                throw new ArgumentException(nameof(model.FileName));
            }

            if (model.Stream is null)
            {
                throw new NullReferenceException($"`Parameter {nameof(model.Stream)}` cannot be null!");
            }

            var objectId = await Validate(entity, guid);

            if (date is null)
            {
                date = DateTime.Now;
            }

            var fileReference = new FileReference
            {
                Date = date.Value,
                Entity = entity,
                Name = model.FileName,
                ObjectId = objectId
            };

            var folder = PathToFolderWithFile(entity, date.Value, fileReference.Guid);
            Directory.CreateDirectory(folder);
            var path = PathToFile(folder, fileReference.Name);

            var uploadTask = UploadFileAsync(model.Stream, path);
            var addTask = ApplicationDbContext.FileReferences.AddAsync(fileReference).AsTask();
            var saveTask = ApplicationDbContext.SaveChangesAsync();

            try
            {
                await Task.WhenAll(uploadTask, addTask, saveTask);
            }
            catch (NotSupportedImageFormatException ex)
            {
                Logger.LogError(ex,
                                "An error occured in {0} while executing tasks: {1}, {2}",
                                GetFullMemberName(),
                                nameof(uploadTask),
                                nameof(addTask),
                                nameof(saveTask));
                throw;
            }
        }
        public virtual async Task UploadAsync(IEnumerable<FileStreamSM> models, string entity, Guid guid, DateTime? date = null)
        {
            if (models is null)
            {
                throw new NullReferenceException($"`Parameter {nameof(models)}` cannot be null!");
            }

            var objectId = await Validate(entity, guid);

            if (date is null)
            {
                date = DateTime.Now;
            }

            var referencePaths = models.Select(x =>
            {
                if (string.IsNullOrWhiteSpace(x.FileName))
                {
                    throw new ArgumentException(nameof(x.FileName));
                }

                if (x.Stream is null)
                {
                    throw new NullReferenceException($"`Parameter {nameof(x.Stream)}` cannot be null!");
                }

                var fileReference = new FileReference
                {
                    Date = date.Value,
                    Entity = entity,
                    Name = x.FileName,
                    ObjectId = objectId
                };
                var folder = PathToFolderWithFile(entity, date.Value, fileReference.Guid);
                Directory.CreateDirectory(folder);

                return new
                {
                    x.Stream,
                    FileReference = fileReference,
                    Path = PathToFile(folder, x.FileName)
                };
            }).ToList();

            try
            {
                await UploadFilesAsync(referencePaths.Select(x => new FileStreamSM(x.Stream, x.Path)));
                await ApplicationDbContext.FileReferences.AddRangeAsync(referencePaths.Select(x => x.FileReference));
                await ApplicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex,
                                "An error occured in {0} while uploading files",
                                GetFullMemberName());
            }
        }
        public virtual async Task<Download> DownloadAsync(Guid guid)
        {
            var fileReference = await ApplicationDbContext.FileReferences
                                                          .AsNoTracking()
                                                          .OrderByDescending(x => x.Date)
                                                          .FirstOrDefaultAsync(x => x.Guid == guid);

            if (fileReference is null)
            {
                throw new FileReferenceNotFound(guid);
            }

            try
            {
                var path = PathToFile(fileReference.Entity, fileReference.Date, fileReference.Guid, fileReference.Name);
                if (File.Exists(path))
                {
                    var stream = new FileStream(path, FileMode.Open);
                    new FileExtensionContentTypeProvider().TryGetContentType(path, out string contentType);
                    return new Download(stream, contentType);
                }
                throw new FileNotFoundException("The specified file is not found!");
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError(ex, "An error occured in {0} while trying to download", GetFullMemberName());
                throw;
            }
        }
        public virtual async Task<Download> DownloadAsync(string entity, Guid guid, DateTime? date = null)
        {
            var objectId = await Validate(entity, guid);

            var fileReferences = ApplicationDbContext.FileReferences
                                                     .AsNoTracking()
                                                     .OrderByDescending(x => x.Date)
                                                     .Where(x => x.ObjectId == objectId && x.Entity == entity && (!date.HasValue || date.Value.Date == x.Date.Date));

            if (!await fileReferences.AnyAsync())
            {
                throw new FileReferenceNotFound(objectId, entity);
            }

            try
            {
                foreach (var fileReference in await fileReferences.ToListAsync())
                {
                    var path = PathToFile(entity, fileReference.Date, fileReference.Guid, fileReference.Name);
                    if (File.Exists(path))
                    {
                        var stream = new FileStream(path, FileMode.Open);
                        new FileExtensionContentTypeProvider().TryGetContentType(path, out string contentType);
                        return new Download(stream, contentType);
                    }
                }
                throw new FileNotFoundException("The specified file is not found!");
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError(ex, "An error occured in {0} while trying to download", GetFullMemberName());
                throw;
            }
        }
        public virtual async Task<IEnumerable<Guid>> GetAsync(string entity, Guid guid, DateTime? date = null, int? size = null, int page = 0)
        {
            if (size < decimal.One)
            {
                throw new ArgumentException("Size of a page should be at least 1 or greater!");
            }

            if (page < decimal.Zero)
            {
                throw new ArgumentException("Page cannot be a negative number!");
            }

            var objectId = await Validate(entity, guid);

            var fileReferences = ApplicationDbContext.FileReferences
                                                     .AsNoTracking()
                                                     .OrderByDescending(x => x.Date)
                                                     .Where(x => x.ObjectId == objectId && x.Entity == entity && (!date.HasValue || date.Value.Date == x.Date.Date));

            if (size.HasValue)
            {
                fileReferences = fileReferences.Skip(size.Value * page).Take(size.Value);
            }

            return fileReferences.Select(x => x.Guid);
        }
        public virtual async Task<Guid?> GetFirstAsync(string entity, Guid guid, DateTime? date = null)
        {
            var objectId = await Validate(entity, guid);

            var fileReferences = ApplicationDbContext.FileReferences
                                                     .AsNoTracking()
                                                     .OrderByDescending(x => x.Date)
                                                     .Where(x => x.ObjectId == objectId && x.Entity == entity && (!date.HasValue || date.Value.Date == x.Date.Date));

            return fileReferences.FirstOrDefault()?.Guid;
        }
        public virtual async Task<int> CountAsync(string entity, Guid guid, DateTime? date = null)
        {
            var objectId = await Validate(entity, guid);

            var count = await ApplicationDbContext.FileReferences.CountAsync(x => x.ObjectId == objectId && x.Entity == entity && (!date.HasValue || date.Value.Date == x.Date.Date));

            return count;
        }
        public virtual async Task<bool> HasMultipleAsync(string entity, Guid guid, DateTime? date = null)
        {
            return await CountAsync(entity, guid, date) > 1;
        }
        public virtual async Task DeleteAsync(Guid guid)
        {
            var fileReference = await ApplicationDbContext.FileReferences.FirstOrDefaultAsync(x => x.Guid == guid);

            if (fileReference is null)
            {
                throw new FileReferenceNotFound(guid);
            }

            var path = PathToFile(fileReference.Entity, fileReference.Date, fileReference.Guid, fileReference.Name);

            try
            {
                var folder = Path.GetDirectoryName(path);
                if (folder != null && Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }
                ApplicationDbContext.FileReferences.Remove(fileReference);
                await ApplicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occured in {0} while trying to delete file!", GetFullMemberName());
                throw;
            }
        }
        public virtual async Task DeleteAllAsync(string entity, Guid guid)
        {
            var objectId = await Validate(entity, guid);

            var fileReferences = ApplicationDbContext.FileReferences.Where(x => x.ObjectId == objectId && x.Entity == entity);

            if (!(await fileReferences.AnyAsync()))
            {
                throw new FileReferenceNotFound(objectId, entity);
            }

            var referencePaths = (await fileReferences.ToListAsync()).Select(x => new
            {
                FileReference = x,
                Path = PathToFile(entity, x.Date, x.Guid, x.Name)
            });

            var current = referencePaths.First();
            try
            {
                foreach (var referencePath in referencePaths)
                {
                    current = referencePath;
                    var folder = Path.GetDirectoryName(referencePath.Path);
                    if (folder != null && Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                    }
                    ApplicationDbContext.FileReferences.Remove(referencePath.FileReference);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occured in {0} while trying to delete file!", GetFullMemberName());
                throw new FileRemovingException(current.Path, current.FileReference);
            }
            finally
            {
                await ApplicationDbContext.SaveChangesAsync();
            }
        }

        #region Helpers
        protected async Task UploadFileAsync(Stream stream, string path)
        {
            await UploadFilesAsync(new[] { new FileStreamSM(stream, path) });
        }
        protected virtual async Task UploadFilesAsync(IEnumerable<FileStreamSM> models)
        {
            foreach (var model in models)
            {
                if (model.Stream != null && model.FileName != null)
                {
                    model.Stream.Seek(0, SeekOrigin.Begin);
                    using var fs = new FileStream(model.FileName, FileMode.OpenOrCreate);
                    await model.Stream.CopyToAsync(fs);
                    await model.Stream.DisposeAsync();
                }
            }
        }
        protected string PathToFolderWithFile(string entity, DateTime date, Guid guid)
        {
            return Path.Combine(Root,
                                entity,
                                date.Date.Year.ToString(),
                                date.Date.Month.ToString(),
                                date.Date.Day.ToString(),
                                guid.ToString());
        }
        protected string PathToFile(string entity, DateTime date, Guid guid, string fileName)
        {
            return Path.Combine(PathToFolderWithFile(entity, date, guid), fileName);
        }
        protected static string PathToFile(string folder, string fileName)
        {
            return Path.Combine(folder, fileName);
        }
        protected virtual async Task<int> Validate(string entity, Guid guid)
        {
            var entityType = ApplicationDbContext.Model.FindEntityType(entity);
            if (entityType is null)
            {
                throw new EntityTypeNotFoundException(entity);
            }

            var dbSet = ApplicationDbContext.GetDbSet<ISecurable>(entityType.ClrType);
            var record = dbSet.FirstOrDefault(x=>x.Guid == guid);

            var data = await ApplicationDbContext.FindAsync(entityType.ClrType, record);
            if (data is null)
            {
                throw new EntityNotFoundException(guid, entityType);
            }

            var objectId = entityType.GetIntegerPrimaryKey(data);
            if (objectId is null)
            {
                throw new PrimaryKeyNotFoundException();
            }

            var primaryKeyValue = entityType.ToObject(objectId.Value);
            var obj = await ApplicationDbContext.FindAsync(entityType.ClrType, primaryKeyValue);
            if (obj is null)
            {
                throw new EntityNotFoundException(guid, entityType);
            }

            return objectId.Value;
        }
        #endregion
    }
}
