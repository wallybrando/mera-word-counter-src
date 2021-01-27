using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Interfaces.Repositories
{
    /// <summary>
    /// Providers data access to Texts table
    /// </summary>
    public interface ITextRepository
    {
        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        Task<Text> ReadText_ById(int id);

        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        Task<List<Text>> ReadTexts();

        /// <summary>
        /// Creates new Text
        /// </summary>
        /// <param name="model">New Text</param>
        /// <returns></returns>
        Task<Text> CreateText(Text model);

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        Task UpdateText(Text text);

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns>True if deletion is successful, otherwise is false</returns>
        Task<bool> DeleteText(int id);
    }
}
