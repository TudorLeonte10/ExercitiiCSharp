using System;

public class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("Baga N: ");
        int.TryParse(Console.ReadLine(), out int n);

        int min = 0;
        int max = n;
        int tries = 0;

        while (true)
        {
            int guess = (min + max) / 2;
            Console.WriteLine($"Is your number {guess}?");
            tries++;
            string response = Console.ReadLine();
            if (response.ToLower() == "Prea mare".ToLower())
            {
                max = guess - 1;
            }
            else if (response.ToLower() == "Prea mic".ToLower())
            {
                min = guess + 1;
            }
            else if (response.ToLower() == "Corect".ToLower())
            {
                Console.WriteLine($"Ce bun sunt. Am ghicit din {tries} incercari.");
                break;
            }
            else
            {
                Console.WriteLine("Raspunde doar cu: 'Prea mare', 'Prea mic' si 'Corect'");
                tries--;
            }
        }
    }
}