using Ex17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17.Services
{
    public class TicketManager
    {
        public List<Movie> Movies { get; } = new();

        public void AddTickets(Ticket ticket)
        {
            var movie = Movies.FirstOrDefault(m => m.Name.Equals(ticket.MovieName, StringComparison.OrdinalIgnoreCase));

            if (movie == null)
            {
                movie = new Movie { Name = ticket.MovieName };
                Movies.Add(movie);
            }

            movie.Tickets.Add(ticket);
        }

        public List<Movie> GetAllMovies() => Movies;
    }
}
