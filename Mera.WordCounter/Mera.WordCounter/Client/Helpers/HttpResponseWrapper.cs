using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mera.WordCounter.Client.Helpers
{
    /// <summary>
    /// Wrapper model for HTTP Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponseWrapper<T>
    {
        public bool Success { get; set; }
        public T Response { get; set; }

        /// <summary>
        /// Gives HttpResponseMessage access to the client of the service
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="response"></param>
        /// <param name="success"></param>
        /// <param name="httpResponseMessage"></param>
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        /// <summary>
        /// Indicates error that occurred
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
