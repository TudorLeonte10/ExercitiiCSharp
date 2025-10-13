using System;
using System.Data;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Introdu o expresie matematica");

        while (true)
        {
            string expression = Console.ReadLine();

            if (expression == "exit")
                break;

            try
            {
                if (!IsValid(expression))
                {
                    Console.WriteLine("Expresia are caractere nepermise");
                    return;
                }

                var result = new DataTable().Compute(expression, null);
                Console.WriteLine($"Rezultatul este: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Impartire la zero");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Eroare de aiurea");
            }
        }
    }

    public static bool IsValid(string s)
    {
        foreach (char c in s)
        {
            if (!char.IsDigit(c) && !"+-*/%() ".Contains(c))
            {
                return false;
            }
        }
        return true;
    }
}