using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Interfaces.Services
{
    /// <summary>
    /// Text Service interface
    /// </summary>
    public interface ITextService
    {
        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        Task<List<Text>> ReadTexts();

        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        Task<Text> ReadText_ById(int id);

        /// <summary>
        /// Creates new Texts
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
        Task<int> CreateText(Text text);

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task UpdateText(Text text);

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns>True if deletion is successful, otherwise is false</returns>
        Task<bool> DeleteText(int id);

        /// <summary>
        /// Calculates total number of words in text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        Task<int> CalculateNumberOfWords(string text);
    }
}
