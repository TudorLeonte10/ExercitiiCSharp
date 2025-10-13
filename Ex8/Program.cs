using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introduceti numarul de elemente pe care vreti sa le vedeti dintr-o secventa");
        int.TryParse(Console.ReadLine(), out int value);
        Console.WriteLine("Intrioduceti tipul de secvente pe care il vreti: 'fiboncaci', 'geometric', 'prime', 'factorial', 'triangle', 'square', 'perfect'");
        string type = Console.ReadLine();

        switch (type)
        {
            case "fibonacci":
                Fibonacci(value);
                break;
            case "geometric":
                Geometricus(value);
                break;
            case "prime":
                Prime(value);
                break;
            case "factorial":
                Factorial(value);
                break;
            case "triangle":
                Triunghiulare(value);
                break;
            case "square":
                Squares(value);
                break;
            case "perfect":
                PerfectNumbers(value);
                break;
            default:
                Console.WriteLine("nu avem asa ceva");
                break;
        }
     }

    public static void Fibonacci(int num)
    {
        int counter = 2;
        int first = 0;
        int second = 1;

        Console.Write($"{first} ");
        Console.Write($"{second} ");

        while (counter < num)
        {
            int next = first + second;
            first = second;
            second = next;
            Console.Write($"{next} ");
            counter++;
        }
    }

    public static void Geometricus(int num)
    {
        int start = 1, ratio = 2;
        for (int i = 0; i < num; i++)
        {
            Console.Write($"{start}");
            start *= ratio;
        }
    }

    public static void Prime(int num) 
    {
        int count = 0, number = 2;
        while (count < num)
        {
            if (IsPrime(number))
            {
                Console.Write($"{number} ");
                count++;
            }
            number++;
        }
    }

    static bool IsPrime(int n)
    {
        if (n < 2)
            return false;

        for(int i = 2; i <= Math.Sqrt(n); i++)
            if(n % i == 0)
                return false;
        return true;
    }

    public static void Factorial(int num)
    {
        long fact = 1;
        for (int i = 1;i <= num; i++)
        {
            fact *= i;
            Console.WriteLine($"{fact} ");
        }
    }

    public static void Triunghiulare(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            int t = i * (i + 1) / 2;
            Console.Write($"{t} ");
        }
    }

    public static void Squares(int num)
    {
        for (int i = 1; i < num; i++)
            Console.Write($"{i * i} ");
    }

    public static void PerfectNumbers(int num)
    {
        for (int i = 1; i < num; i++)
        {
            if (IsPerfect(i))
                Console.Write($"{i} ");
        }
    }

    public static bool IsPerfect (int n)
    {
        int sumDiv = 0;
        for(int d = 1;  d <= n/2; d++)
        {
            if(n % d == 0)
            {
                sumDiv += d;
            }
        }
        if (sumDiv == n)
            return true;
        return false;
    }
}