using Ex8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8.Generators
{
    public class FactorialGenerator : ISequenceGenerator
    {
        public string Name => "factorial";

        public IEnumerable<long> Generate(int count)
        {
            long fact = 1;
            for (int i = 1; i <= count; i++)
            {
                fact *= i;
                yield return fact;
            }
        }
    }
}
