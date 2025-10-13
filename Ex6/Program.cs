using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introduceti un numar:");
        int.TryParse(Console.ReadLine(), out int value);

        for (int i = 1; i <= value; i++)
        {
            for (int j = 1; j <= value; j++)
            {
                Console.Write($"{ i* j,4}");
            }
            Console.WriteLine();
        }
    }
}
