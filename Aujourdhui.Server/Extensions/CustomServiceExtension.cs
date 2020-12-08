using Aujourdhui.Infrastructure.Services;
using Aujourdhui.Infrastructure.Services.ImageFormatters;
using Aujourdhui.Services.ContentServices;
using Aujourdhui.Services.ContentServices.ImageFormatters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Aujourdhui.Server.Extensions
{
    public static class CustomServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddContentsServices();
        }

        private static void AddContentsServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IImageService, ImageService>();

            serviceCollection.AddTransient<IImageFormatterService, ImageFormatterService>();

            serviceCollection.AddTransient<IProportionFormatter, OriginProportionFormatter>();
            serviceCollection.AddTransient<IProportionFormatter, SquareProportionFormatter>();

            serviceCollection.AddTransient<ProportionServiceResolver>((serviceProvider) => 
                key => serviceProvider.GetServices<IProportionFormatter>()
                                      .FirstOrDefault(x => x.Proportion == key));
        }
    }
}
