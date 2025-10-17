using Ex17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex17.Interfaces;

namespace Ex17.Services
{
    public class AddTicketsCommand : ICommand
    {
        public string Name => "add";
        private readonly TicketManager _manager;
        private readonly IUserInterface _ui;

        public AddTicketsCommand(TicketManager manager, IUserInterface ui)
        {
            _manager = manager;
            _ui = ui;
        }

        public void Execute()
        {
            string movieName = _ui.GetInput("Enter movie name: ");
            string screenInput = _ui.GetInput("Enter screen type (2d, 3d, 4d): ").ToLower();

            ScreenType screenType = screenInput switch
            {
                "2d" => ScreenType.TwoD,
                "3d" => ScreenType.ThreeD,
                "4d" => ScreenType.FourD,
                _ => ScreenType.TwoD
            };

            string seatCategory = _ui.GetInput("Enter seat category (front/middle/back): ").ToLower();

            string priceInput = _ui.GetInput("Enter base ticket price (RON): ");
            if (!decimal.TryParse(priceInput, out decimal basePrice) || basePrice <= 0)
            {
                _ui.ShowMessage("Invalid price.");
                return;
            }

            string quantityInput = _ui.GetInput("Enter number of tickets: ");
            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                _ui.ShowMessage("Invalid ticket count.");
                return;
            }

            var ticket = new Ticket
            {
                MovieName = movieName,
                Type = screenType,
                SeatCategory = seatCategory,
                BasePrice = basePrice,
                Quantity = quantity
            };

            _manager.AddTickets(ticket);
            _ui.ShowMessage($"Tickets added for {movieName} ({quantity} seats, {screenType}).");
        }
    }
}
