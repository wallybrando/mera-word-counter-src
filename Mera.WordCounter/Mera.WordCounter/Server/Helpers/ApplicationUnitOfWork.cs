using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces;
using Mera.WordCounter.Server.Interfaces.Repositories;
using Mera.WordCounter.Server.Repository;

namespace Mera.WordCounter.Server.Helpers
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private ITextRepository textRepository;

        public ApplicationUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public ITextRepository TextRepository
        {
            get
            {
                return textRepository ??= new TextRepository(context);
            }
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
