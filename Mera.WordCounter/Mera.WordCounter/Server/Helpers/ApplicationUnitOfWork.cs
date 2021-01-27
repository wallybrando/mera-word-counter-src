using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces;
using Mera.WordCounter.Server.Interfaces.Repositories;
using Mera.WordCounter.Server.Repository;

namespace Mera.WordCounter.Server.Helpers
{
    /// <summary>
    /// Unit of Work design pattern
    /// </summary>
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ITextRepository _textRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public ApplicationUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        /// <summary>
        /// Text Repository Getter
        /// </summary>
        public ITextRepository TextRepository
        {
            get
            {
                return _textRepository ??= new TextRepository(_context);
            }
        }

        /// <summary>
        /// Saves Changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
