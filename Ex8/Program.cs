using Ex8;
using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Sequence Generator Application");
        Console.WriteLine("Available sequences: " + string.Join(", ", SequenceFactory.GetAvailable()));

        while (true)
        {
            Console.Write("\nEnter sequence name (or 'exit' to quit): ");
            string? seqName = Console.ReadLine()?.Trim().ToLower();
            if (seqName == "exit")
                break;

            var generator = SequenceFactory.GetGenerator(seqName ?? "");
            if (generator == null)
            {
                Console.WriteLine("Unknown sequence type.");
                continue;
            }

            Console.Write("Enter number of terms: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number of terms.");
                continue;
            }

            var sequence = generator.Generate(count);
            Console.WriteLine($"\n{generator.Name.ToUpper()} sequence ({count} terms):");
            Console.WriteLine(string.Join(", ", sequence));
        }

        Console.WriteLine("\nProgram terminated.");
    }
}
