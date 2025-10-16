using Ex6.Interfaces;
using Ex6.Services;
using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        ITableGenerator generator = new MultiplicationTableGenerator();
        var table = generator.Generate(number);

        var printer = new ConsoleTablePrinter();
        printer.Print(table);
    }

}

