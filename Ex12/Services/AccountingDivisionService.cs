using Ex12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Services
{
    public class AccountingDivisionService : IDivisionService
    {
        public decimal Divide(decimal numerator, decimal denominator, int decimals = 2)
        {
            if(denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }

            return Math.Round(numerator / denominator, decimals, MidpointRounding.ToEven);
        }
    }
}
