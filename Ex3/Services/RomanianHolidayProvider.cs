using Ex3.Interfaces;
using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Services
{
    public class RomanianHolidayProvider : IHolidayProvider
    {
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            return new List<Holiday>
            {
                new Holiday { Name = "New Year", Date = new DateTime(year, 1, 1) },
                new Holiday { Name = "Day After New Year", Date = new DateTime(year, 1, 2) },
                new Holiday { Name = "Unification Day", Date = new DateTime(year, 1, 24) },
                new Holiday { Name = "Labour Day", Date = new DateTime(year, 5, 1) },
                new Holiday { Name = "Children's Day", Date = new DateTime(year, 6, 1) },
                new Holiday { Name = "Assumption of Mary", Date = new DateTime(year, 8, 15) },
                new Holiday { Name = "Saint Andrew", Date = new DateTime(year, 11, 30) },
                new Holiday { Name = "National Day", Date = new DateTime(year, 12, 1) },
                new Holiday { Name = "Christmas Day", Date = new DateTime(year, 12, 25) },
                new Holiday { Name = "Second Day of Christmas", Date = new DateTime(year, 12, 26) }
            };
        }
    }
}
