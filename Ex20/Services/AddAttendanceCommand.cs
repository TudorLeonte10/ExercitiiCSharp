using Ex20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex20.Interfaces;

namespace Ex20.Services
{
    public class AddAttendanceCommand : ICommand
    {
        public string Name => "add";
        private readonly AttendanceManager _manager;

        public AddAttendanceCommand(AttendanceManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            string name = _manager.UI.GetInput("Enter employee name: ");
            string dateInput = _manager.UI.GetInput("Enter attendance date (yyyy-mm-dd): ");

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                _manager.UI.ShowMessage("Invalid date format.");
                return;
            }

            var record = new AttendanceRecord { EmployeeName = name, Date = date };
            _manager.Repository.Add(record);
            _manager.UI.ShowMessage($"Attendance recorded for {name} on {date:yyyy-MM-dd}");
        }
    }
}
