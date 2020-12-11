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
using Microsoft.AspNetCore.StaticFiles;
using Aujourdhui.Extensions.ImageExtensions;

#nullable enable

namespace Aujourdhui.Services.ContentServices
{
    public class ImageService : FileService, IImageService
    {
        public const string ImagesFolder = "Images";
        public static readonly IDictionary<ImageFormat, IEnumerable<string>> RequiredFormats = new Dictionary<ImageFormat, IEnumerable<string>>
        {
            { ImageFormat.Jpeg, new [] { ".jpeg", ".jpg" } },
            { ImageFormat.Png, new [] { ".png" } },
            { ImageFormat.Gif, new [] { ".gif" } },
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

        public async Task<Download> DownloadAsync(Guid guid,
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
                    new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);
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
        public async Task<Download> DownloadAsync(string entity,
                                                  Guid guid,
                                                  DateTime? date = null,
                                                  ImageSize size = ImageSize.Origin,
                                                  ImageProportion proportion = ImageProportion.Origin)
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
                    var fileName = ImageFormatterService.SpecifyImagePath(fileReference.Name, size, proportion);
                    var path = PathToFile(fileReference.Entity, fileReference.Date, fileReference.Guid, fileName);
                    if (File.Exists(path))
                    {
                        var stream = new FileStream(path, FileMode.Open);
                        new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);
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


        #region Helpers
        protected override async Task UploadFilesAsync(IEnumerable<FileStreamSM> models)
        {
            foreach (var model in models)
            {
                var extension = Path.GetExtension(model.FileName);
                if (!RequiredFormats.Values.SelectMany(formats => formats).Any(x => x.Equals(extension)))
                {
                    throw new NotSupportedImageFormatException(extension);
                }
            }

#if DEBUG
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("{0} - Processing images...", GetFullMemberName());
            Stopwatch.Restart();
#endif

            var proportionSizes = from size in ImageFormatterService.Sizes.DefaultIfEmpty()
                                  from proportion in ImageFormatterService.Proportions.DefaultIfEmpty()
                                  select new { Size = size, Proportion = proportion };

            var capacity = models.Count();
            var tasks = new List<Task>(capacity);
            var disposings = new List<Task>(capacity);
            Parallel.ForEach(models, model =>
            {
                if (model.Stream is null)
                {
                    throw new NullReferenceException($"Parameter `{nameof(model.Stream)}` cannot be null!");
                }

                var image = Image.FromStream(model.Stream);

                if (!image.IsCorrectImageFormat(RequiredFormats.Select(x => x.Key)))
                {
                    throw new NotSupportedImageFormatException(image.RawFormat.ToString());
                }

                var fileStreams = proportionSizes.Where(x => ImageFormatterService.CanBeProcessed(image,
                                                                                                  x.Size,
                                                                                                  x.Proportion))
                                                 .Select(x =>
                                                 {
                                                     var memoryStream = new MemoryStream();
                                                     var processed = ImageFormatterService.ProcessImage(image, x.Size, x.Proportion);
                                                     processed.Save(memoryStream, image.RawFormat);
                                                     return new FileStreamSM
                                                     {
                                                         Stream = memoryStream,
                                                         FileName = ImageFormatterService.SpecifyImagePath(model.FileName,
                                                                                                           x.Size,
                                                                                                           x.Proportion)
                                                     };
                                                 })
                                                 .ToList();

                tasks.Add(base.UploadFilesAsync(fileStreams));
                disposings.Add(Task.Run(() => image.Dispose()));
            });

            await Task.WhenAll(tasks.ToArray());
            await Task.WhenAll(disposings.ToArray());

#if DEBUG

            Stopwatch.Stop();
            Console.WriteLine("{0} - Processing images took:", GetFullMemberName());
            Console.WriteLine(Stopwatch.Elapsed);
#endif
        }
        #endregion
    }
}
