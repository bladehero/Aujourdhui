using Aujourdhui.ViewModels.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aujourdhui.Server.Controllers
{
    [Route("api/[controller]")]
    public class ErrorsController : ControllerBase
    {
        [AllowAnonymous]
        public ErrorVM Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = 500; 

            if (exception is Exception) code = 500;

            Response.StatusCode = code;

            return new ErrorVM(exception);
        }
    }
}
