using Ex18.Interfaces;
using Ex18.Repositories;
using Ex18.Services;
using System;

namespace Ex18 {
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine(" To-Do List Application\n");

            IUserInterface ui = new ConsoleUserInterface();
            ITaskRepository repo = new JsonTaskRepository();
            var manager = new TaskManager(repo, ui);
            var commands = CommandRegistry.Build(manager);

            while (true)
            {
                ui.ShowMessage("\nAvailable commands: add | edit | remove | show | exit");
                string input = ui.GetInput("> ").Trim().ToLower();

                if (input == "exit")
                {
                    ui.ShowMessage(" Goodbye!");
                    break;
                }

                if (commands.TryGetValue(input, out ICommand? command))
                {
                    command.Execute();
                }
                else
                {
                    ui.ShowMessage(" Unknown command.");
                }
            }
        }
    }
}