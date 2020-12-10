using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Services.Exceptions;
using Aujourdhui.Services.Models.FileServiceModels;
using Aujourdhui.Services.Models.ImageServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aujourdhui.Server.Areas.Content.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public IImageService ImageService { get; }
        public ILogger<ImagesController> Logger { get; }

        public ImagesController(IImageService imageService, ILogger<ImagesController> logger)
        {
            ImageService = imageService;
            Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid guid,
                                             ImageSize imageSize = ImageSize.Origin,
                                             ImageProportion imageProportion = ImageProportion.Origin)
        {
            var download = await ImageService.DownloadAsync(guid, imageSize, imageProportion);
            return new FileStreamResult(download.Stream, download.ContentType);
        }

        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        public async Task<bool> Post(IFormFileCollection formFileCollection)
        {
            var models = formFileCollection.Select(x => new FileStreamSM(x.OpenReadStream(), x.FileName)).ToList();
            bool result;
            if (models.Count == 1)
            {
                result = await ImageService.UploadAsync(models.First(), "Aujourdhui.Data.Models.Languages.LanguageValue", 1);
            }
            else
            {
                result = await ImageService.UploadAsync(models, "Aujourdhui.Data.Models.Languages.LanguageValue", 1);
            }
            return result;
        }
    }
}
