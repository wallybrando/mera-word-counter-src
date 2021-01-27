using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Interfaces.Consumers;
using Mera.WordCounter.Client.Interfaces.Helpers;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Client.Consumers
{
    /// <summary>
    /// Text Consumer
    /// </summary>
    public class TextConsumer : ITextConsumer
    {
        private readonly IHttpService _httpService;
        private string url = "api/texts";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpService">HttpService interface</param>
        public TextConsumer(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Gets a Text with HTTP GET Action
        /// </summary>
        /// <returns></returns>
        public async Task<Text> GetText(int id)
        {
            var response = await _httpService.Get<Text>($"{url}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        /// <summary>
        /// Gets all Texts from storage with HTTP GET Action
        /// </summary>
        /// <returns></returns>
        public async Task<List<Text>> GetTexts()
        {
            var response = await _httpService.Get<List<Text>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        /// <summary>
        /// Creates Text with HTTP POST Action
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
        public async Task<int> CreateText(Text text)
        {
            var response = await _httpService.Post<Text, int>(url, text);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        /// <summary>
        /// Updates Text with HTTP PUT Action
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        public async Task UpdateText(Text text)
        {
            var response = await _httpService.Put(url, text);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        /// <summary>
        /// Deletes Text with HTTP DELETE Action
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        public async Task DeleteText(int id)
        {
            var response = await _httpService.Delete($"{url}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        /// <summary>
        /// Calculates total number of words in text 
        /// </summary>
        /// <param name="text">Text Model</param>
        /// <returns></returns>
        public async Task<int> CalculateNumberOfWords(Text text)
        {
            var response = await _httpService.Post<Text, int>($"{url}/calculate", text);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
