using Ex7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Services
{
    public class BinaryGuessingStrategy : IGuessingStrategy
    {
        private int _low;
        private int _high;
        private int _current;
        private int _attempts;

        public int Attempts => _attempts;

        public BinaryGuessingStrategy(int baseNumber)
        {
            _low = 1;
            _high = baseNumber;
            _current = (_low + _high) / 2;
            _attempts = 0;
        }

        public int NextGuess()
        {
            _attempts++;
            _current = (_low + _high) / 2;
            return _current;
        }

        public void ProcessFeedback(string feedback)
        {
            switch (feedback.ToLower())
            {
                case "too low":
                    _low = _current + 1;
                    break;
                case "too high":
                    _high = _current - 1;
                    break;
                case "correct":
                    break;
            }
        }
    }
}
