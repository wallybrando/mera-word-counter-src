using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Interfaces.Repositories
{
    public interface ITextRepository
    {
        Task<List<Text>> ReadTexts();

        Task<Text> CreateText(Text model);
    }
}
