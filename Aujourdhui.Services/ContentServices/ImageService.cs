using Aujourdhui.Data;
using Aujourdhui.Services.Models.ImageServiceModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Services.Models.FileServiceModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using System.Drawing;

#nullable enable

namespace Aujourdhui.Services.ContentServices
{
    public class ImageService : FileService, IImageService
    {
        public const string ImagesFolder = "Images";
        public static readonly IEnumerable<ImageFormat> RequiredFormats = new[]
        {
            ImageFormat.Jpeg,
            ImageFormat.Png,
            ImageFormat.Gif
        };

        protected IImageFormatterService ImageFormatterService { get; }

        public ImageService(ILogger<FileService> logger,
                            IHttpContextAccessor httpContext,
                            ApplicationDbContext applicationDbContext,
                            IWebHostEnvironment webHostEnvironment,
                            IImageFormatterService imageFormatterService)
            : base(logger, httpContext, applicationDbContext, webHostEnvironment)
        {
            ImageFormatterService = imageFormatterService;
        }

        protected override string Root => Path.Combine(base.Root, ImagesFolder);

        public async Task<Stream> DownloadAsync(Guid guid,
                                                ImageSize size = ImageSize.Origin,
                                                ImageProportion proportion = ImageProportion.Origin)
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
                var fileName = ImageFormatterService.SpecifyImagePath(fileReference.Name, size, proportion);
                var path = PathToFile(fileReference.Entity, fileReference.Date, fileReference.Guid, fileName);
                if (File.Exists(path))
                {
                    var stream = new FileStream(path, FileMode.Open);
                    return stream;
                }
                throw new FileNotFoundException("The specified file is not found!");
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError(ex, "An error occured in {0} while trying to download", GetFullMemberName());
                throw;
            }
        }
        public async Task<Stream> DownloadAsync(string entity,
                                                int objectId,
                                                DateTime? date = null,
                                                ImageSize size = ImageSize.Origin,
                                                ImageProportion proportion = ImageProportion.Origin)
        {
            var entityType = ApplicationDbContext.Model.FindEntityType(entity) ?? throw new EntityTypeNotFoundException(entity);

            var primaryKeyValue = PrepareIdToObject(entityType, objectId);
            var obj = await ApplicationDbContext.FindAsync(entityType.ClrType, primaryKeyValue);

            if (obj is null)
            {
                throw new EntityNotFoundException(objectId, entityType);
            }

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
                    var fileName = ImageFormatterService.SpecifyImagePath(fileReference.Name, size, proportion);
                    var path = PathToFile(fileReference.Entity, fileReference.Date, fileReference.Guid, fileName);
                    if (File.Exists(path))
                    {
                        var stream = new FileStream(path, FileMode.Open);
                        return stream;
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
        public override Task<bool> OverwriteAsync(FileStreamSM model, Guid guid)
        {
            if (!IsCorrectImageFormat(model.Stream, RequiredFormats))
            {
                var extension = Path.GetExtension(model.FileName);
                throw new NotSupportedImageFormatException(extension);
            }

            return base.OverwriteAsync(model, guid);
        }
        public override Task<bool> UploadAsync(FileStreamSM model, string entity, int objectId, DateTime? date = null)
        {
            if (!IsCorrectImageFormat(model.Stream, RequiredFormats))
            {
                var extension = Path.GetExtension(model.FileName);
                throw new NotSupportedImageFormatException(extension);
            }

            return base.UploadAsync(model, entity, objectId, date);
        }
        public override Task<bool> UploadAsync(IEnumerable<FileStreamSM> models, string entity, int objectId, DateTime? date = null)
        {
            if (models.FirstOrDefault(x => !IsCorrectImageFormat(x.Stream, RequiredFormats)) is FileStreamSM model)
            {
                var extension = Path.GetExtension(model.FileName);
                throw new NotSupportedImageFormatException(extension);
            }

            return base.UploadAsync(models, entity, objectId, date);
        }

        #region Helpers
        protected override Task UploadFilesAsync(IEnumerable<FileStreamSM> models)
        {
#if DEBUG
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("{0} - Generating a list of valid images...", GetFullMemberName());
            Stopwatch.Restart();
#endif

            var results = (from model in models
                           from size in ImageFormatterService.Sizes.DefaultIfEmpty()
                           from proportion in ImageFormatterService.Proportions.DefaultIfEmpty()
                           where ImageFormatterService.CanBeProcessed(model.Stream, size, proportion)
                           select new { Model = model, Size= size,Proportion = proportion});

            var list = new List<FileStreamSM>(results.Count());
            foreach (var result in results)
#if DEBUG

            Stopwatch.Stop();
            Console.WriteLine("{0} - Generating a list of valid images took:", GetFullMemberName());
            Console.WriteLine(Stopwatch.Elapsed);
#endif

            ;

#if DEBUG
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("{0} - Starting processing images...", GetFullMemberName());
            Stopwatch.Restart();
#endif
            {
                var stream = ImageFormatterService.ProcessImage(result.Model.Stream, result.Size, result.Proportion);
                if (stream is null)
                {
                    continue;
                }

                var model = new FileStreamSM
                {
                    FileName = ImageFormatterService.SpecifyImagePath(result.Model.FileName, result.Size, result.Proportion),
                    Stream = stream
                };
                list.Add(model);
            }
#if DEBUG
            Stopwatch.Stop();
            Console.WriteLine("{0} - Processing images took:", GetFullMemberName());
            Console.WriteLine(Stopwatch.Elapsed);
#endif

            return base.UploadFilesAsync(list);
        }
        public static bool IsCorrectImageFormat(Stream stream, IEnumerable<ImageFormat> imageFormats)
        {
            using (var image = Image.FromStream(stream))
            {
                foreach (var format in imageFormats)
                {
                    if (image.RawFormat.Equals(format))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
