using Ex19.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex19.Models;

namespace Ex19.Services.Commands
{
    public class AddItemCommand : ICommand
    {
        public string Name => "add";
        private readonly IUserInterface _userInterface;
        private readonly IBookService _service;

        public AddItemCommand(IBookService service, IUserInterface userInterface)
        {
            _service = service;
            _userInterface = userInterface;
        }

        public void Execute()
        {
            string type = _userInterface.GetInput("Enter item type (book/magazine): ").ToLower();
            string title = _userInterface.GetInput("Enter book title: ");
            string author = _userInterface.GetInput("Enter book author: ");
            string yearString = _userInterface.GetInput("Enter publication year: ");
            int.TryParse(yearString, out int year);

            if (type == "book")
            {
                string input = _userInterface.GetInput("Enter number of pages: ");
                if (!int.TryParse(input, out int pages) || pages <= 0)
                {
                    _userInterface.ShowMessage("Invalid number of pages.");
                    return;
                }
                _service.AddItem(new Book
                {
                    Title = title,
                    Author = author,
                    Year = year,
                    Pages = pages
                });
            }
            else if (type == "magazine")
            {
                string input = _userInterface.GetInput("Enter issue number: ");
                if (!int.TryParse(input, out int issueNumber) || issueNumber <= 0)
                {
                    _userInterface.ShowMessage("Invalid issue number.");
                    return;
                }
                _service.AddItem(new Magazine
                {
                    Title = title,
                    Author = author,
                    Year = year,
                    IssueNumber = issueNumber
                });
            }
            else
            {
                _userInterface.ShowMessage("Unknown item type.");
                return;
            }

        }
    }
}
