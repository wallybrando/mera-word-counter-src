using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Repositories;
using Mera.WordCounter.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mera.WordCounter.Server.Repository
{
    public class TextRepository : ITextRepository
    {
        private readonly ApplicationDbContext context;

        public TextRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Text>> ReadTexts()
        {
            return await context.Texts.ToListAsync();
        }

        public async Task<Text> CreateText(Text model)
        {
            // validate required field
            var entity = await context.Texts.AddAsync(model);

            return entity.Entity;
        }
    }
}
