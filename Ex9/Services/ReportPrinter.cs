using Ex9.Interfaces;
using Ex9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9.Services
{
    public class ReportPrinter
    {
        private readonly IUserInterface _ui;

        public ReportPrinter(IUserInterface ui)
        {
            _ui = ui;
        }

        public void Print(decimal amount, string targetCurrency, List<CurrencyRate> rates, ICurrencyConverter converter)
        {
            _ui.ShowMessage($"\nCurrency conversion report for the last {rates.Count} days");
            _ui.ShowMessage($"Amount in RON: {amount}");
            _ui.ShowMessage($"Target currency: {targetCurrency}\n");

            _ui.ShowMessage("Date       | Currency | Rate (RON/unit) | Converted Amount");
            _ui.ShowMessage("-----------+----------+-----------------+-----------------");

            foreach (var rate in rates)
            {
                var converted = converter.Convert(amount, rate.Rate);
                _ui.ShowMessage($"{rate.Date:yyyy-MM-dd} | {rate.Currency,-8} | {rate.Rate,15:F3} | {converted,15:F2}");
            }

            var avgRate = rates.Average(r => r.Rate);
            var avgConverted = converter.Convert(amount, avgRate);
            _ui.ShowMessage($"\nAverage rate: {avgRate:F3}");
            _ui.ShowMessage($"Average converted amount: {avgConverted:F2} {targetCurrency}");
        }
    }
}
