using Ex9.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex9.Models;

namespace Ex9.Services
{
    public class HardcodedRateProvider : ICurrencyRateProvider
    {
        public List<CurrencyRate> GetRates(string currencyCode, int days)
        {
            var rates = new List<CurrencyRate>();
            var random = new Random();

            decimal baseRate = currencyCode.ToUpper() switch
            {
                "EUR" => 4.95m,
                "USD" => 4.60m,
                "GBP" => 5.75m,
                _ => 4.95m
            };

            for (int i = days - 1; i >= 0; i--)
            {
                var rate = baseRate + (decimal)(random.NextDouble() - 0.5) * 0.1m; 
                rates.Add(new CurrencyRate
                {
                    Date = DateTime.Today.AddDays(-i),
                    Currency = currencyCode.ToUpper(),
                    Rate = Math.Round(rate, 3)
                });
            }

            return rates;
        }
    }
}
