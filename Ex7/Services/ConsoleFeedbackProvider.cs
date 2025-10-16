using Ex7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Services
{
    public class ConsoleFeedbackProvider : IUserFeedbackProvider
    {
        public string GetFeedback(int guess)
        {
            Console.Write($"Is your number {guess}? (too high / too low / correct): ");
            var input = Console.ReadLine()?.Trim().ToLower();

            while (input != "too high" && input != "too low" && input != "correct")
            {
                Console.Write("Please type: 'too high', 'too low' or 'correct': ");
                input = Console.ReadLine()?.Trim().ToLower();
            }

            return input!;
        }
    }
}
