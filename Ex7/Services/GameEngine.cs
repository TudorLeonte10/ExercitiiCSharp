using Ex7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Services
{
    public class GameEngine
    {
        private readonly IGuessingStrategy _strategy;
        private readonly IUserFeedbackProvider _feedbackProvider;

        public GameEngine(IGuessingStrategy strategy, IUserFeedbackProvider feedbackProvider)
        {
            _strategy = strategy;
            _feedbackProvider = feedbackProvider;
        }

        public void Start()
        {
            Console.WriteLine("\nThink of a number — I will try to guess it!");
            string feedback;

            do
            {
                int guess = _strategy.NextGuess();
                feedback = _feedbackProvider.GetFeedback(guess);
                _strategy.ProcessFeedback(feedback);
            }
            while (feedback != "correct");

            Console.WriteLine($"\n I guessed it in {_strategy.Attempts} attempts!");
        }
    }
}
