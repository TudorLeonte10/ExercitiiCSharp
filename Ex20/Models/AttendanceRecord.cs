using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Models
{
    public class AttendanceRecord
    {
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} | {EmployeeName}";
        }
    }
}
