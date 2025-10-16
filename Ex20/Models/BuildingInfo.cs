using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Models
{
    public class BuildingInfo
    {
        public int BuildingCapacity { get; set; }
        public int CompanyEmployeeCount { get; set; }

        public double CapacityRate => (double)BuildingCapacity / CompanyEmployeeCount * 100;
    }
}
