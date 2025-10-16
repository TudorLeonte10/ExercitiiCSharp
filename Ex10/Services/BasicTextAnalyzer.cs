using Ex10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Services
{
    public class BasicTextAnalyzer : ITextAnalyzer
    {
        private static readonly HashSet<char> Vowels = new HashSet<char>("aeiouăâîAEIOUĂÂÎ");

        public int CountCharacters(string text)
        {
            return text.Length;
        }

        public int CountWords(string text)
        {
            var words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public int NumberOfConsonants(string text)
        {
            return text.Count(c => char.IsLetter(c) && !Vowels.Contains(c));
        }

        public int NumberOfVowels(string text)
        {
            return text.Count(c => Vowels.Contains(c));
        }
    }
}
