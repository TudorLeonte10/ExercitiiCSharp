using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services.Commands
{
    public class ReturnItemCommand : ICommand
    {
        public string Name => "return";

        private readonly IUserInterface _userInterface;
        private readonly IBookService _service;

        public ReturnItemCommand(IBookService service, IUserInterface userInterface)
        {
            _service = service;
            _userInterface = userInterface;
        }

        public void Execute()
        {
            string title = _userInterface.GetInput("Enter the title of the book/magazine to return: ");
            string name = _userInterface.GetInput("Enter your name: ");

            _service.ReturnItem(title, name);
            _userInterface.ShowMessage($"Thank you, {name}. You have successfully returned '{title}'.");
        }
    }
}
