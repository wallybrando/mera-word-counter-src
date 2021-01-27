using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Repositories;

namespace Mera.WordCounter.Server.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IApplicationUnitOfWork
    {
        /// <summary>
        /// Text Repository Getter
        /// </summary>
        ITextRepository TextRepository { get; }

        /// <summary>
        /// Saves Changes
        /// </summary>
        /// <returns></returns>
        Task<int> Save();
    }
}
