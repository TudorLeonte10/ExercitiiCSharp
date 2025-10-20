using Ex19.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Services
{
    public class LibraryManager
    {
        private readonly IUserInterface ui;
        private readonly Dictionary<string, ICommand> commands;

        public LibraryManager(IBookService service, IUserInterface ui)
        {
            this.commands = CommandRegistry.Build(service, ui);
            this.ui = ui;
        }
        public void Run()
        {
            ui.ShowMessage("Welcome to the Library Management System!");
            while (true)
            {
                ui.ShowMessage("Available commands: add, delete, borrow, return, show, report, exit");
                string input = ui.GetInput("Enter command: ").ToLower();

                if (input == "exit")
                {
                    break;
                }

                if (commands.TryGetValue(input, out ICommand? command))
                {
                    command.Execute();
                }
                else
                {
                    ui.ShowMessage("Unknown command. Please try again.");
                }
            }
        }
    }
}
