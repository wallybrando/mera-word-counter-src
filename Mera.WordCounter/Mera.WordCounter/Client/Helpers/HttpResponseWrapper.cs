using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mera.WordCounter.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public bool Success { get; set; }
        public T Response { get; set; }
        /// <summary>
        /// Gives HttpResponseMessage access to the client of the service
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }


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
