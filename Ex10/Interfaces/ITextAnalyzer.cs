using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Interfaces
{
    public interface ITextAnalyzer
    {
        int CountWords(string text);
        int CountCharacters(string text);
        int NumberOfVowels(string text);
        int NumberOfConsonants(string text);
    }
}
