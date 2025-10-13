using System;

public class Progam
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introduceti 2 numere cu zecimale:");
        decimal.TryParse(Console.ReadLine(), out decimal nr1);
        decimal.TryParse(Console.ReadLine(), out decimal nr2);

        try
        {
            var res = nr1 / nr2;
            res = Math.Round(res, 2, MidpointRounding.ToEven);
            Console.WriteLine(res);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}