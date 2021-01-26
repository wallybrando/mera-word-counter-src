using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Client.Interfaces.Consumers
{
    public interface ITextConsumer
    {
        Task<List<Text>> GetTexts();

        Task<int> CalculateNumberOfWords(Text text);
    }
}
