using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services.Commands
{
    public class ReportCommand : ICommand
    {
        public string Name => "report";
        private readonly IBookService _service;
        private readonly IUserInterface _ui;

        public ReportCommand(IBookService service, IUserInterface ui)
        {
            _service = service;
            _ui = ui;
        }

        public void Execute()
        {
            var history = _service.GetBorrowHistory();
            if (!history.Any())
            {
                _ui.ShowMessage("No borrow history yet.");
                return;
            }

            _ui.ShowMessage("\n--- Borrow History ---");
            foreach (var record in history)
                _ui.ShowMessage(record.ToString());

            var overdue = history.Where(r => r.IsOverdue()).ToList();
            if (overdue.Any())
            {
                _ui.ShowMessage("\n--- Overdue Borrowers ---");
                foreach (var r in overdue)
                    _ui.ShowMessage($"{r.PersonName} - '{r.BorrowedItemTitle}' borrowed on {r.BorrowDate:yyyy-MM-dd}");
            }
        }
    }
   }
