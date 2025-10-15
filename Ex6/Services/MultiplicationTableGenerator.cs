using Ex6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6.Services
{
    public class MultiplicationTableGenerator : ITableGenerator
    {
        public int[,] Generate(int number)
        {
            int[,] table = new int[number, number];

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    table[i, j] = (i + 1) * (j + 1);
                }
            }

            return table;
        }
    }
}
