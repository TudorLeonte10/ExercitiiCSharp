using Ex7.Interfaces;
using Ex7.Services;
using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine(" Number Guessing Game");

        int baseNumber = int.Parse(Console.ReadLine());

        IGuessingStrategy strategy = new BinaryGuessingStrategy(baseNumber);
        IUserFeedbackProvider feedbackProvider = new ConsoleFeedbackProvider();
        var engine = new GameEngine(strategy, feedbackProvider);

        engine.Start();
    }
}