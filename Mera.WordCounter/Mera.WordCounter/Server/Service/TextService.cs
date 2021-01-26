using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces;
using Mera.WordCounter.Server.Interfaces.Services;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Service
{
    public class TextService : ITextService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TextService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Text>> ReadTexts()
        {
            return await _unitOfWork.TextRepository.ReadTexts();
        }

        public async Task<int> CreateText(Text text)
        {
            var model = await _unitOfWork.TextRepository.CreateText(text);

            if (model == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            await _unitOfWork.Save();

            return model.Id;
        }

        public async Task<int> CalculateNumberOfWords(string text)
        {
            int result = 0;

            //Trim whitespace from beginning and end of string
            text = text.Trim();

            //Necessary because foreach will execute once with empty string returning 1
            if (text == "")
            {
                return await Task.FromResult(0);
            }

            //Ensure there is only one space between each word in the passed string
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            //Count the words
            foreach (string y in text.Split(' '))
            {
                result++;
            }

            return await Task.FromResult(result); ;
        }
    }
}
