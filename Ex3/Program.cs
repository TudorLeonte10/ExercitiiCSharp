using Ex3.Interfaces;
using Ex3.Services;
using System;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Year Analyzer");
        Console.Write("Enter a year: ");

        if (!int.TryParse(Console.ReadLine(), out var year) || year < 1)
        {
            Console.WriteLine("Invalid year.");
            return;
        }

        IYearRule leapRule = new LeapYearRule();
        IHolidayProvider holidays = new RomanianHolidayProvider();
        var calculator = new YearCalculator(leapRule, holidays);

        var info = calculator.Analyze(year);

        Console.WriteLine($"\nYear: {info.Year}");
        Console.WriteLine($"Leap year: {(info.IsLeapYear ? "Yes" : "No")}");
        Console.WriteLine($"Total days: {info.TotalDays}");
        Console.WriteLine($"Work days: {info.WorkDays}");
        Console.WriteLine($"Weeks: {info.Weeks}");
        Console.WriteLine($"\n Holidays:");

        foreach (var h in info.Holidays)
            Console.WriteLine($"- {h}");
    }
}
