using Ex20.Interfaces;
using Ex20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Services
{
    public class AttendanceManager
    {
        public readonly IAttendanceRepository Repository;
        public readonly IUserInterface UI;
        public readonly List<Employee> Employees;
        public readonly BuildingInfo Building;

        public AttendanceManager(IAttendanceRepository repository, IUserInterface ui)
        {
            Repository = repository;
            UI = ui;

            Employees = new List<Employee>
            {
                new Employee { Name = "Alex", DaysRequiredPerWeek = 2 },
                new Employee { Name = "Tudor", DaysRequiredPerWeek = 2 },
                new Employee { Name = "Maria", DaysRequiredPerWeek = 2 },
                new Employee { Name = "Andrei", DaysRequiredPerWeek = 2 }
            };

            Building = new BuildingInfo
            {
                BuildingCapacity = 3,
                CompanyEmployeeCount = Employees.Count
            };
        }
    }
}
