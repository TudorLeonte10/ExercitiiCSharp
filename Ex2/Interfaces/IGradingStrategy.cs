using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Interfaces
{
    public interface IGradingStrategy
    {
        string Name { get; }
        double CalculateAverage(IEnumerable<double> grades);
    }
}
