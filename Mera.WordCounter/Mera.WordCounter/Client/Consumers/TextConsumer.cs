using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Interfaces.Consumers;
using Mera.WordCounter.Client.Interfaces.Helpers;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Client.Consumers
{
    public class TextConsumer : ITextConsumer
    {
        private readonly IHttpService httpService;
        private string url = "api/texts";

        public TextConsumer(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Text>> GetTexts()
        {
            var response = await httpService.Get<List<Text>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<int> CalculateNumberOfWords(Text text)
        {
            var response = await httpService.Post<Text, int>(url, text);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
