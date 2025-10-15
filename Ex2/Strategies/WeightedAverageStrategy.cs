using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Strategies
{
    public class WeightedAverageStrategy : IGradingStrategy
    {
        public string Name => "Weighted Average (First exam counts double)";

        public double CalculateAverage(IEnumerable<double> grades)
        {
            if (!grades.Any()) return 0;
            var list = grades.ToList();
            double total = 0, weightSum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                double weight = (i == 0) ? 2 : 1;
                total += list[i] * weight;
                weightSum += weight;
            }

            return total / weightSum;
        }
    }

}
