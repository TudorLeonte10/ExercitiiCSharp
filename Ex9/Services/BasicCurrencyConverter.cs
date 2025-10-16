using Ex9.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9.Services
{
    public class BasicCurrencyConverter : ICurrencyConverter
    {
        public decimal Convert(decimal amount, decimal rate)
        {
            return Math.Round(amount / rate, 2);
        }
    }
}
