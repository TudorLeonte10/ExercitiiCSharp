using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public class YearInfo
    {
        public int Year { get; set; }
        public bool IsLeapYear { get; set; }
        public int TotalDays { get; set; }
        public int WorkDays { get; set; }
        public int Weeks { get; set; }
        public List<Holiday> Holidays { get; set; } = new();
    }
}
