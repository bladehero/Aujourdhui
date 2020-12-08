using Aujourdhui.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Aujourdhui.Services
{
    public abstract class BaseService<T>
    {
        protected ILogger<T> Logger { get; }
        protected IHttpContextAccessor HttpContext { get; }
        protected ApplicationDbContext ApplicationDbContext { get; }

        public BaseService(ILogger<T> logger,
                           IHttpContextAccessor httpContext,
                           ApplicationDbContext applicationDbContext)
        {
            Logger = logger;
            HttpContext = httpContext;
            ApplicationDbContext = applicationDbContext;
        }

        public string GetFullMemberName([CallerMemberName] string callerName = "")
        {
            return $"{GetType().FullName}.{callerName}";
        }
    }
}
