using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17.Models
{
    public class Movie
    {
        public string Name { get; set; } = string.Empty;
        public List<Ticket> Tickets { get; set; } = new();

        public decimal TotalRevenue => Tickets.Sum(t => t.CalculateTotal());
    }
}
