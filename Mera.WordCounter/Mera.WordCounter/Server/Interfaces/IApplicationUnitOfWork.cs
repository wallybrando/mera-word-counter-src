using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Repositories;

namespace Mera.WordCounter.Server.Interfaces
{
    public interface IApplicationUnitOfWork
    {
        ITextRepository TextRepository { get; }
        Task<int> Save();
    }
}
