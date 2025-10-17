using Ex13.Interfaces;
using Ex13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13.Services
{
    public class PayrollManager
    {
        private readonly IUserInterface _ui;
        private readonly ISalaryCalculator _calculator;

        public PayrollManager(IUserInterface ui, ISalaryCalculator calculator)
        {
            _ui = ui;
            _calculator = calculator;
        }

        public void Run()
        {
            _ui.ShowMessage("Salary Calculator\n");

            string name = _ui.GetInput("Enter employee name: ");
            string hireDateInput = _ui.GetInput("Enter hire date (yyyy-MM-dd): ");

            if (!DateTime.TryParse(hireDateInput, out DateTime hireDate))
            {
                _ui.ShowMessage("Invalid date format.");
                return;
            }

            string hoursInput = _ui.GetInput("Enter number of hours worked per week: ");
            if (!int.TryParse(hoursInput, out int weeklyHours) || weeklyHours <= 0)
            {
                _ui.ShowMessage("Invalid hours input.");
                return;
            }

            string rateInput = _ui.GetInput("Enter current hourly rate (RON): ");
            if (!decimal.TryParse(rateInput, out decimal hourlyRate) || hourlyRate <= 0)
            {
                _ui.ShowMessage("Invalid hourly rate.");
                return;
            }

            var employee = new Employee
            {
                Name = name,
                HireDate = hireDate,
                WeeklyHours = weeklyHours,
                HourlyRate = hourlyRate
            };

            decimal gross = _calculator.CalculateMonthlyGross(employee);
            decimal deductions = _calculator.CalculateDeductions(gross);
            decimal net = _calculator.CalculateNet(gross, deductions);
            decimal totalEarned = _calculator.CalculateTotalEarned(employee);

            _ui.ShowMessage("\n--- Salary Report ---");
            _ui.ShowMessage($"Employee: {employee.Name}");
            _ui.ShowMessage($"Hire Date: {employee.HireDate:yyyy-MM-dd}");
            _ui.ShowMessage($"Years of Experience: {employee.YearsOfExperience:F1} years");
            _ui.ShowMessage($"Weekly Hours: {employee.WeeklyHours}");
            _ui.ShowMessage($"Hourly Rate (adjusted): {gross / (employee.WeeklyHours * 4):F2} RON");
            _ui.ShowMessage($"\nMonthly Gross: {gross:F2} RON");
            _ui.ShowMessage($"Deductions (taxes + contributions): {deductions:F2} RON");
            _ui.ShowMessage($"Monthly Net Salary: {net:F2} RON");
            _ui.ShowMessage($"Total Earned (since hire): {totalEarned:F2} RON");
        }
    }
}
