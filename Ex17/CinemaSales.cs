using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17
{
    internal class CinemaSales
    {
        private readonly List<Ticket> _tickets = new();
        
        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public double GetTotalIncome()
        {
            double total = 0;
            foreach (Ticket ticket in _tickets)
            {
                total += ticket.FinalPrice;
            }

            return total;
        }

        public void ShowReport()
        {
            Console.WriteLine("Bilete vandute:");
            foreach (Ticket ticket in _tickets)
            {
                Console.WriteLine(ticket);
            }
            Console.WriteLine($" Total încasari: {GetTotalIncome()} lei");
        }
    }
}
