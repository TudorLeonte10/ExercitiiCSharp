using Ex14;
using System;

public class Program
{
    static void Main(string[] args)
    {
        var acc = new BankAccount("B1234", "Tudy");
        acc.Deposit(1000000);
        try
        {
            acc.WithDraw(20000000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        acc.DisplaySold();
    }
}