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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork interface</param>
        public TextService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        public async Task<Text> ReadText_ById(int id)
        {
            return await _unitOfWork.TextRepository.ReadText_ById(id);
        }

        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        public async Task<List<Text>> ReadTexts()
        {
            return await _unitOfWork.TextRepository.ReadTexts();
        }

        /// <summary>
        /// Creates new Texts
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task UpdateText(Text text)
        {
            await _unitOfWork.TextRepository.UpdateText(text);
        }

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns>True if deletion is successful, otherwise is false</returns>
        public async Task<bool> DeleteText(int id)
        {
            return await _unitOfWork.TextRepository.DeleteText(id);
        }

        /// <summary>
        /// Calculates total number of words in text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        public async Task<int> CalculateNumberOfWords(string text)
        {
            /*** Trim whitespace from beginning and end of string *******************************/
            text = text.Trim();

            /*** Necessary because foreach will execute once with empty string returning 1 ******/
            if (text == "")
            {
                return await Task.FromResult(0);
            }

            /*** Ensure there is only one space between each word in the passed string **********/
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }


            /*** Count the words ****************************************************************/
            var words = text.Split(new[] {" ", ",", "-", "!", "."}, StringSplitOptions.RemoveEmptyEntries);

            return await Task.FromResult(words.Length); ;
        }
    }
}
