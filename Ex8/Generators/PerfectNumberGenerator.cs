using Ex8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8.Generators
{
    public class PerfectNumberGenerator : ISequenceGenerator
    {
        public string Name => "perfect";

        public IEnumerable<long> Generate(int count)
        {
            int found = 0;
            int n = 2;

            while (found < count)
            {
                if (IsPerfect(n))
                {
                    yield return n;
                    found++;
                }
                n++;
            }
        }

        private bool IsPerfect(int num)
        {
            int sum = 1;
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                    sum += i;
            }
            return sum == num && num != 1;
        }
    }
}
