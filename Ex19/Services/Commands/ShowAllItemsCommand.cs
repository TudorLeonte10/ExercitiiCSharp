using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services.Commands
{
    public class ShowAllItemsCommand : ICommand
    {
        public string Name => "show";
        private readonly IBookService _service;
        private readonly IUserInterface _ui;
        public ShowAllItemsCommand(IBookService service, IUserInterface ui)
        {
            _service = service;
            _ui = ui;
        }

        public void Execute()
        {
           var items = _service.GetAllItems();
           if (!items.Any())
              {
                _ui.ShowMessage("No items available.");
                return;
            }
              _ui.ShowMessage("\n--- All Items ---");
              foreach (var item in items)
                {
                    _ui.ShowMessage(item.ToString());
            }
        }
    }
}
