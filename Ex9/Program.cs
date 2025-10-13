using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introdu suma de bani in lei");
        int.TryParse(Console.ReadLine(), out int value);
        Console.WriteLine("Introdu moneda la care vrei sa faci conversie");
        string currency = Console.ReadLine();

        Console.WriteLine($"{"Data",-12} {"Curs",-10} {"Suma Convertita",-20}");
        Console.WriteLine(new string('-', 42));

        Random random = new Random();
        double cursBaza = currency.ToUpper() switch
        {
            "EUR" => 5.09,
            "USD" => 4.39,
            "GBP" => 5.87,
            _ => 1
        };

        for (int i = 0; i < 30; i++)
        {
            DateTime dateTime = DateTime.Now.AddDays(-i);
            double variation = 1 + (random.NextDouble() - 0.5) / 25;
            double curs = Math.Round(cursBaza * variation, 4);
            double conversion = Math.Round(value/curs, 4);

            Console.WriteLine($"{dateTime:dd.MM.yyyy} {curs,-10} {conversion,-20}");
        }
    }
}