using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex20.Interfaces;

namespace Ex20.Services
{
    public class ShowReportCommand : ICommand
    {
        public string Name => "report";
        private readonly AttendanceManager _manager;

        public ShowReportCommand(AttendanceManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            var generator = new ReportGenerator();
            var records = _manager.Repository.GetAll();
            var report = generator.Generate(_manager.Employees, records, _manager.Building);

            _manager.UI.ShowMessage("\nAttendance Report");
            _manager.UI.ShowMessage($"Total employees: {report.TotalEmployees}");
            _manager.UI.ShowMessage($"Building capacity: {report.BuildingCapacity}");
            _manager.UI.ShowMessage($"Total present: {report.TotalPresent}");
            _manager.UI.ShowMessage($"Attendance %: {report.AttendancePercentage:F2}%");

            if (report.EmployeesMissingQuota.Any())
            {
                _manager.UI.ShowMessage("\nEmployees below 2-day quota:");
                foreach (var emp in report.EmployeesMissingQuota)
                    _manager.UI.ShowMessage($" - {emp}");
            }
            else
            {
                _manager.UI.ShowMessage("\nAll employees met attendance quota!");
            }
        }
    }
}
