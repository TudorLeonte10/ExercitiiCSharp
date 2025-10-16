using Ex8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8.Generators
{
    public class TriangularGenerator : ISequenceGenerator
    {
        public string Name => "triangular";

        public IEnumerable<long> Generate(int count)
        {
            for (int n = 1; n <= count; n++)
                yield return n * (n + 1) / 2;
        }
    }

}
