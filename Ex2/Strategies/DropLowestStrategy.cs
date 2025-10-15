using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Strategies
{
    public class DropLowestStrategy : IGradingStrategy
    {
        public string Name => "Drop Lowest Grade";

        public double CalculateAverage(IEnumerable<double> grades)
        {
            var list = grades.ToList();
            if (list.Count <= 1) return list.FirstOrDefault();
            list.Remove(list.Min());
            return list.Average();
        }
    }
}
