using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("(Omul A) Man, hai sa ne intalnim candva");
        Console.WriteLine("(Omul B) Hai. Scrie tu data si ora la care ar fi ok pentru tine si eu iti confirm daca pot");
        string data = Console.ReadLine();
        string ora = Console.ReadLine();
        Console.WriteLine($"Eu as putea pe {data} la ora {ora}. E ok?");

        DateTime dataIntalnire;
        string combined = $"{data} {ora}";

        if (DateTime.TryParse(combined, out dataIntalnire))
        {
            Console.WriteLine($"Da, e bine. Deci ramane sa ne vedem exact atunci: {dataIntalnire}");
        }
        else
        {
            Console.WriteLine("Error: data/ora nu e scrisa bine");

        }
    }
}