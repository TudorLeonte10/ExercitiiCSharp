using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Strategies
{
    public class SimpleAverageStrategy : IGradingStrategy
    {
        public string Name => "Simple Average";

        public double CalculateAverage(IEnumerable<double> grades)
            => grades.Any() ? grades.Average() : 0;
    }
}
