using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex17.Interfaces;

namespace Ex17.Services
{
    public class ReportCommand : ICommand
    {
        public string Name => "report";
        private readonly TicketManager _manager;
        private readonly IUserInterface _ui;

        public ReportCommand(TicketManager manager, IUserInterface ui)
        {
            _manager = manager;
            _ui = ui;
        }

        public void Execute()
        {
            var movies = _manager.GetAllMovies();
            if (!movies.Any())
            {
                _ui.ShowMessage("No tickets sold yet.");
                return;
            }

            _ui.ShowMessage("\n--- Cinema Sales Report ---");
            foreach (var movie in movies)
            {
                _ui.ShowMessage($"\nMovie: {movie.Name}");
                _ui.ShowMessage("Tickets:");
                foreach (var t in movie.Tickets)
                {
                    _ui.ShowMessage($" - {t.Quantity}x {t.SeatCategory} ({t.Type}) @ {t.BasePrice} RON");
                }

                _ui.ShowMessage($"Total Revenue: {movie.TotalRevenue:F2} RON");
            }

            decimal totalAll = movies.Sum(m => m.TotalRevenue);
            _ui.ShowMessage($"\nTotal Revenue for all movies: {totalAll:F2} RON");
        }
    }
}
