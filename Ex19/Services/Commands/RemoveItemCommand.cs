using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services.Commands
{
    public class RemoveItemCommand : ICommand
    {
        public string Name => "delete";
        private readonly IBookService _service;
        private readonly IUserInterface _ui;

        public RemoveItemCommand(IBookService service, IUserInterface ui)
        {
            _service = service;
            _ui = ui;
        }

        public void Execute()
        {
            string title = _ui.GetInput("Enter the title of the book/magazine to remove: ");
            _service.RemoveItem(title);
            _ui.ShowMessage($"Item with title '{title}' has been removed.");
        }
    }
}
