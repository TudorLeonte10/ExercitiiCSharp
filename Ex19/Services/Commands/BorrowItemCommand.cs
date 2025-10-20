using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services.Commands
{
    public class BorrowItemCommand : ICommand
    {
        public string Name => "borrow";
        private readonly IUserInterface _userInterface;
        private readonly IBookService _service;

        public BorrowItemCommand (IBookService service, IUserInterface userInterface)
        {
            _service = service;
            _userInterface = userInterface;
        }

        public void Execute()
        {
            string title = _userInterface.GetInput("Enter the title of the book to borrow: ");
            string name = _userInterface.GetInput("Enter your name: ");

            _service.BorrowItem(title, name);
            _userInterface.ShowMessage($"You have successfully borrowed '{title}'.");
        }
    }
}
