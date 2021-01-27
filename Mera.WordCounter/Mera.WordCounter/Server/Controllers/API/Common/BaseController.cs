using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mera.WordCounter.Server.Controllers.API.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TController"></typeparam>
    public class BaseController<TService, TController> : ControllerBase where TService : class
    {
        protected TService Service { get; }

        protected ILogger<TController> Logger { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public BaseController(TService service, ILogger<TController> logger)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected virtual ActionResult ProcessException(Exception ex)
        {
            // Log it first
            Logger.LogError("Exception in API call: ", ex);

            // Security exception: We won't send any detailed messages back to the client
            // to prevent revealing sensitive information.
            if (ex is SecurityException)
            {
                return Content(HttpStatusCode.Forbidden.ToString());
            }

            // Handle validation errors, give as much details as possible.
            if (ex is ValidationException)
            {
                return Content(HttpStatusCode.BadRequest.ToString());
            }

            // Generic argument exception, just forward error message
            if (ex is ArgumentException)
            {
                if (ex is ArgumentNullException)
                {
                    return Content(HttpStatusCode.NotFound.ToString());
                }

                return Content(HttpStatusCode.BadRequest.ToString());
            }

            // Internal server error means that something unexpected happened. We'll return
            // error without details to prevent revealing sensitive information.
            return Content(HttpStatusCode.InternalServerError.ToString());
        }
    }
}
