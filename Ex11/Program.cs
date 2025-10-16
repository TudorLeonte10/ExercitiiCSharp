using Ex11.Interfaces;
using Ex11.Services;
using System;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Meeting Planner Application\n");

        IUserInterface ui = new ConsoleUserInterface();
        var manager = new MeetingManager(ui);
        var commands = CommandRegistry.Build(manager, ui);

        while (true)
        {
            ui.ShowMessage("\nAvailable commands: add | confirm | show | exit");
            string input = ui.GetInput("> ").Trim().ToLower();

            if (input == "exit")
            {
                ui.ShowMessage("Program ended.");
                break;
            }

            if (commands.TryGetValue(input, out ICommand? command))
                command.Execute();
            else
                ui.ShowMessage("Unknown command.");
        }
    }
}