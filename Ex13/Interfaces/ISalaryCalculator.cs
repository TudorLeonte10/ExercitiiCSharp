using Ex13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13.Interfaces
{
    public interface ISalaryCalculator
    {
        decimal CalculateMonthlyGross(Employee employee);
        decimal CalculateDeductions(decimal gross);
        decimal CalculateNet(decimal gross, decimal deductions);
        decimal CalculateTotalEarned(Employee employee);
    }
}
