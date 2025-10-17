using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13.Models
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public decimal HourlyRate { get; set; }
        public int WeeklyHours { get; set; }

        public decimal YearsOfExperience
        {
            get
            {
                var span = DateTime.Now - HireDate;
                return (decimal)span.TotalDays / 365;
            }
        }
    }
}
