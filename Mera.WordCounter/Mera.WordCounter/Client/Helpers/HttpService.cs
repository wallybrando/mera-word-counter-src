using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Interfaces.Helpers;

namespace Mera.WordCounter.Client.Helpers
{
    /// <summary>
    /// Initiate HTTP Request to WebAPI
    /// </summary>
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions defaultJsonSerializerOptions => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Initiates GET request to the WEB API
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="url">URI to call</param>
        /// <returns>Rest API result</returns>
        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHttp, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHttp);
            }

            return new HttpResponseWrapper<T>(default, false, responseHttp);
        }

        /// <summary>
        ///  Initiates POST request to the WEB API
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <typeparam name="TResponse">Result type</typeparam>
        /// <param name="url">URI to call</param>
        /// <param name="data">Resource</param>
        /// <returns>Rest API result</returns>
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContext = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContext);

            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }

            return new HttpResponseWrapper<TResponse>(default, false, response);
        }

        /// <summary>
        /// Initiates PUT request to the WEB API
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <param name="url">URI to call</param>
        /// <param name="data">Resource</param>
        /// <returns>Rest API result</returns>
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContext = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, stringContext);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        /// <summary>
        /// Initiates DELETE request to the WEB API
        /// </summary>
        /// <param name="url">URI to call</param>
        /// <returns>Rest API result</returns>
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHttp = await _httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, responseHttp.IsSuccessStatusCode, responseHttp);
        }

        /// <summary>
        /// Deserializes response
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="httpResponse">Http Response from Web API</param>
        /// <param name="options">JsonSerializationOption</param>
        /// <returns></returns>
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
