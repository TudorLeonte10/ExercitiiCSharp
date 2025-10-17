using Ex16;
using Ex16.Interfaces;
using Ex16.Services;
using System;


internal class Program
{
    static void Main()
    {

        IUserInterface ui = new ConsoleUserInterface();
        ICarEvaluator evaluator = new BasicCarEvaluator();
        var manager = new CarManager(ui, evaluator);

        manager.Run();
    }
}