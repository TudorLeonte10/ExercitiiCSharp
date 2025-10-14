using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.Strategies
{
    internal class EqualTemperatureStrategy : ITemperatureComparisonStrategy
    {
        public bool Matches(double currentTemp, double avgTemp)
            => currentTemp == avgTemp;

        public string GetMessage() => "Temperatura este egala cu media.";
    }
}
