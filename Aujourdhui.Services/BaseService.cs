using Aujourdhui.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Aujourdhui.Services
{
    public abstract class BaseService<T>
    {
        protected ILogger<T> Logger { get; }
        protected IHttpContextAccessor HttpContext { get; }
        protected ApplicationDbContext ApplicationDbContext { get; }

#if DEBUG
        protected Stopwatch Stopwatch { get; }
#endif

        public BaseService(ILogger<T> logger,
                           IHttpContextAccessor httpContext,
                           ApplicationDbContext applicationDbContext)
        {
            Logger = logger;
            HttpContext = httpContext;
            ApplicationDbContext = applicationDbContext;
            Stopwatch = new Stopwatch();
        }

        public string GetFullMemberName([CallerMemberName] string callerName = "")
        {
            return $"{GetType().FullName}.{GetMemberName(callerName)}";
        }
        public string GetMemberName([CallerMemberName] string callerName = "")
        {
            return $"{callerName}";
        }
    }
}
