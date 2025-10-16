using Ex1;
using Ex1.Interfaces;
using System;
using System.Data;
using System.Globalization;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Basic Calculator");
        OperationFactory.ListAvailable();
        Console.WriteLine("Example: 5 + 3 * 2");

        Console.Write("\nEnter expression: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(" Empty input.");
            return;
        }

        try
        {
            var result = EvaluateExpression(input);
            Console.WriteLine($"\n Result = {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }
    }

    static double EvaluateExpression(string input)
    {
        var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length < 3 || tokens.Length % 2 == 0)
            throw new InvalidOperationException("Invalid expression format.");

        double result = double.Parse(tokens[0]);

        for (int i = 1; i < tokens.Length; i += 2)
        {
            string symbol = tokens[i];
            double nextValue = double.Parse(tokens[i + 1]);

            IOperation? op = OperationFactory.GetOperation(symbol)
                ?? throw new InvalidOperationException($"Unknown operator: {symbol}");

            result = op.Execute(result, nextValue);
        }

        return result;
    }
}
