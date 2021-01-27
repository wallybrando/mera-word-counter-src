using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Repositories;
using Mera.WordCounter.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mera.WordCounter.Server.Repository
{
    /// <summary>
    /// Texts Repository
    /// </summary>
    public class TextRepository : ITextRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TextRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns></returns>
        public async Task<Text> ReadText_ById(int id)
        {
            /*** Parameter check*********************************/
            if (id <= 0)
            {
                throw new ArgumentException("Text Id can't be 0 or lower");
            }

            return await context.Texts.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        public async Task<List<Text>> ReadTexts()
        {
            return await context.Texts.ToListAsync();
        }

        /// <summary>
        /// Creates new Text
        /// </summary>
        /// <param name="model">New Text</param>
        /// <returns></returns>
        public async Task<Text> CreateText(Text model)
        {
            /*** Parameter check*********************************/
            // Validate text input via annotations
            Validator.ValidateObject(model, new ValidationContext(model), true);

            // validate required field
            var entity = await context.Texts.AddAsync(model);

            return entity.Entity;
        }

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        public async Task UpdateText(Text text)
        {
            /*** Parameter check*********************************/
            if (text.Id <= 0)
            {
                throw new ArgumentException("Text Id can't be less or equal to 0");
            }

            // Validate text input via annotations
            Validator.ValidateObject(text, new ValidationContext(text), true);

            context.Attach(text).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id">Text Id</param>
        /// <returns>True if deletion is successful, otherwise is false</returns>
        public async Task<bool> DeleteText(int id)
        {
            /*** Parameter check*********************************/
            if (id <= 0)
            {
                throw new ArgumentException("Text Id can't be 0 or lower");
            }

            var text = await context.Texts.FirstOrDefaultAsync(x => x.Id == id);

            if (text == null) return false;

            context.Remove(text);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
