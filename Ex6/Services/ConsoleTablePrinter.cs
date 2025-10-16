using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6.Services
{
    public class ConsoleTablePrinter
    {
        public void Print(int[,] table)
        {
            int size = table.GetLength(0);

            Console.WriteLine("\n Multiplication Table\n");

            Console.Write("    ");
            for (int j = 1; j <= size; j++)
                Console.Write($"{j,4}");
            Console.WriteLine();
            Console.WriteLine(new string('-', size * 4 + 4));

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1,2} |");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{table[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}
