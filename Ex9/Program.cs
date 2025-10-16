using Ex9.Interfaces;
using Ex9.Services;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static void Main(string[] args)
    {
        IUserInterface ui = new ConsoleUserInterface();
        ICurrencyRateProvider rateProvider = new HardcodedRateProvider();
        ICurrencyConverter currencyConverter = new BasicCurrencyConverter();
        var printer = new ReportPrinter(ui);

        string amount = ui.GetInput("Enter amount in RON: ");
        decimal.TryParse(amount, out decimal amountValue);
        string currency = ui.GetInput("Enter target currency (EUR, USD, GBP): ").ToUpper();

        var rates = rateProvider.GetRates(currency, 30);
        printer.Print(amountValue, currency, rates, currencyConverter);
    }
}