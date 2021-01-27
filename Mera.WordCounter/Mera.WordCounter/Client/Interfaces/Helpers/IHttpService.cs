using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Helpers;

namespace Mera.WordCounter.Client.Interfaces.Helpers
{
    /// <summary>
    /// Initiate HTTP Request to WebAPI
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Initiates GET request to the WEB API
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="url">URI to call</param>
        /// <returns>Rest API result</returns>
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        /// <summary>
        ///  Initiates POST request to the WEB API
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <typeparam name="TResponse">Result type</typeparam>
        /// <param name="url">URI to call</param>
        /// <param name="data">Resource</param>
        /// <returns>Rest API result</returns>
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);

        /// <summary>
        /// Initiates PUT request to the WEB API
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <param name="url">URI to call</param>
        /// <param name="data">Resource</param>
        /// <returns>Rest API result</returns>
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data);

        /// <summary>
        /// Initiates DELETE request to the WEB API
        /// </summary>
        /// <param name="url">URI to call</param>
        /// <returns>Rest API result</returns>
        Task<HttpResponseWrapper<object>> Delete(string url);
    }
}
