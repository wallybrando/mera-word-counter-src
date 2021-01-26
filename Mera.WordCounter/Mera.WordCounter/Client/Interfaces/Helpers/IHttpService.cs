using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Helpers;

namespace Mera.WordCounter.Client.Interfaces.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
    }
}
