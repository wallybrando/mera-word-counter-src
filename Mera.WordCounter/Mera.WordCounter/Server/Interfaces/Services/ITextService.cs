using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Interfaces.Services
{
    public interface ITextService
    {
        Task<List<Text>> ReadTexts();

        Task<int> CreateText(Text text);

        Task<int> CalculateNumberOfWords(string text);
    }
}
