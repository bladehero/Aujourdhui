using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Services.Models.FileServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Aujourdhui.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        public IImageService ImageService { get; }

        public Test(IImageService imageService)
        {
            ImageService = imageService;
        }


        [HttpGet("hasMultiple")]
        public async Task<bool> GetHasMultiple(string entity, int objectId, DateTime? date = null)
        {
            var result = await ImageService.HasMultipleAsync(entity, objectId, date);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string entity, int objectId, DateTime? date = null)
        {
            var result = await ImageService.DownloadAsync(entity, objectId, date);
            return new FileStreamResult(result, MediaTypeNames.Image.Jpeg);
        }

        [HttpPost]
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

        [HttpDelete]
        public async Task Delete(int objectId, string entity)
        {
            await ImageService.DeleteAllAsync(entity, objectId);
        }

        [HttpDelete("{guid}")]
        public async Task Delete(Guid guid)
        {
            await ImageService.DeleteAsync(guid);
        }
    }
}
