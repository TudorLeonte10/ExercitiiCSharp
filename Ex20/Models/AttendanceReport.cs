using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Models
{
    public class AttendanceReport
    {
        public int TotalEmployees { get; set; }
        public int TotalPresent { get; set; }
        public int BuildingCapacity { get; set; }
        public double AttendancePercentage { get; set; }
        public List<string> EmployeesMissingQuota { get; set; } = new();
    }
}
