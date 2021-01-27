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
    /// Base controller implementation. All controllers on the server side should inherit from this one
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TController"></typeparam>
    public class BaseController<TService, TController> : ControllerBase where TService : class
    {
        /// <summary>
        /// Service: used for all operations that controller supports
        /// </summary>
        protected TService Service { get; }

        /// <summary>
        /// Logger: used for logging actions
        /// </summary>
        protected ILogger<TController> Logger { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Generic Service</param>
        /// <param name="logger">Generic Logger</param>
        public BaseController(TService service, ILogger<TController> logger)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Common exception handler
        /// </summary>
        /// <param name="ex">Input exception</param>
        /// <returns>Action result according to input exception</returns>
        protected virtual ActionResult ProcessException(Exception ex)
        {
            // Log it first
            Logger.LogError("Exception in API call: ", ex);

            // Security exception
            if (ex is SecurityException)
            {
                return Content(HttpStatusCode.Forbidden.ToString());
            }

            // Handle validation errors
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

            // Internal server error means that something unexpected happened
            return Content(HttpStatusCode.InternalServerError.ToString());
        }
    }
}
