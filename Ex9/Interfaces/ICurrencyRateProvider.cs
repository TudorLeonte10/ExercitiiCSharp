using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex9.Models;

namespace Ex9.Interfaces
{
    public interface ICurrencyRateProvider
    {
        List<CurrencyRate> GetRates(string currencyCode, int days); 
    }
}
