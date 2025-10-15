using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Interfaces
{
    public interface IGuessingStrategy
    {
        int NextGuess();
        void ProcessFeedback(string feedback);
        int Attempts { get; }
    }
}
