using Ex8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8.Generators
{
    public class FibonacciGenerator : ISequenceGenerator
    {
        public string Name => "fibonacci";

        public IEnumerable<long> Generate(int count)
        {
            long a = 0, b = 1;
            for (int i = 0; i < count; i++)
            {
                yield return a;
                long temp = a + b;
                a = b;
                b = temp;
            }
        }
    }
}
