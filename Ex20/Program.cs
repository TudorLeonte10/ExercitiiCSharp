using Ex20;
using Ex20.Interfaces;
using Ex20.Repositories;
using Ex20.Services;
using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Attendance Management System\n");

        IUserInterface ui = new ConsoleUserInterface();
        IAttendanceRepository repo = new JsonAttendanceRepository();
        var manager = new AttendanceManager(repo, ui);
        var commands = CommandRegistry.Build(manager);

        while (true)
        {
            ui.ShowMessage("\nAvailable commands: add | report | exit");
            string input = ui.GetInput("> ").Trim().ToLower();

            if (input == "exit")
            {
                ui.ShowMessage("Goodbye!");
                break;
            }

            if (commands.TryGetValue(input, out ICommand? command))
                command.Execute();
            else
                ui.ShowMessage("Unknown command.");
        }
    }
}
