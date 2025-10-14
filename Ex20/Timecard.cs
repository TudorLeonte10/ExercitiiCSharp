using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20
{
    internal class Timecard
    {
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }

        public Timecard(Employee employee, DateTime date)
        {
            Employee = employee;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Employee.Name} - {Date:dd.MM.yyyy}";
        }
    }
}
