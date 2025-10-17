using Ex13.Interfaces;
using Ex13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13.Services
{
    public class BasicSalaryCalculator : ISalaryCalculator
    {
        private const decimal TaxRate = 0.10m;      
        private const decimal SocialContribution = 0.25m; 

        public decimal CalculateMonthlyGross(Employee employee)
        {
            decimal baseRate = employee.HourlyRate;

            if (employee.YearsOfExperience >= 5 && employee.YearsOfExperience < 10)
                baseRate *= 1.10m; 
            else if (employee.YearsOfExperience >= 10)
                baseRate *= 1.25m; 

            decimal weeklySalary = baseRate * employee.WeeklyHours;
            return weeklySalary * 4; 
        }

        public decimal CalculateDeductions(decimal gross)
        {
            return Math.Round(gross * (TaxRate + SocialContribution), 2, MidpointRounding.ToEven);
        }

        public decimal CalculateNet(decimal gross, decimal deductions)
        {
            return Math.Round(gross - deductions, 2, MidpointRounding.ToEven);
        }

        public decimal CalculateTotalEarned(Employee employee)
        {
            decimal monthlyGross = CalculateMonthlyGross(employee);
            int monthsWorked = ((DateTime.Now.Year - employee.HireDate.Year) * 12) + DateTime.Now.Month - employee.HireDate.Month;
            if (monthsWorked < 1) monthsWorked = 1; 

            return monthlyGross * monthsWorked;
        }
    }
}
