using Ex20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Services
{
    public class ReportGenerator
    {
        public AttendanceReport Generate(
            List<Employee> employees,
            List<AttendanceRecord> records,
            BuildingInfo building)
        {
            var report = new AttendanceReport
            {
                TotalEmployees = employees.Count,
                TotalPresent = records.Select(r => r.EmployeeName).Distinct().Count(),
                BuildingCapacity = building.BuildingCapacity
            };

            report.AttendancePercentage = (double)report.TotalPresent / report.TotalEmployees * 100;

            var grouped = records
                .GroupBy(r => r.EmployeeName)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var emp in employees)
            {
                if (!grouped.ContainsKey(emp.Name) || grouped[emp.Name] < emp.DaysRequiredPerWeek)
                    report.EmployeesMissingQuota.Add(emp.Name);
            }

            return report;
        }
    }
}
