using Ex17;
using Ex17.Services;
using System;
using Ex17.Interfaces;

internal class Program
{
    static void Main()
    {
        IUserInterface ui = new ConsoleUserInterface();
        var manager = new TicketManager();
        var commands = CommandRegistry.Build(manager, ui);

        while (true)
        {
            ui.ShowMessage("\nAvailable commands: add | report | exit");
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

