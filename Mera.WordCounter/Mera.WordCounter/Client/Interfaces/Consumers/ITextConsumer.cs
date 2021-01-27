using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Client.Interfaces.Consumers
{
    /// <summary>
    /// Text API consumer
    /// </summary>
    public interface ITextConsumer
    {
        /// <summary>
        /// Gets a Text with HTTP GET Action
        /// </summary>
        /// <returns></returns>
        Task<Text> GetText(int id);

        /// <summary>
        /// Gets all Texts from storage with HTTP GET Action
        /// </summary>
        /// <returns></returns>
        Task<List<Text>> GetTexts();

        /// <summary>
        /// Creates Text with HTTP POST Action
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
        Task<int> CreateText(Text text);

        /// <summary>
        /// Updates Text with HTTP PUT Action
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        Task UpdateText(Text text);

        /// <summary>
        /// Deletes Text with HTTP DELETE Action
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        Task DeleteText(int id);

        /// <summary>
        /// Calculates total number of words in text 
        /// </summary>
        /// <param name="text">Text Model</param>
        /// <returns></returns>
        Task<int> CalculateNumberOfWords(Text text);
    }
}
