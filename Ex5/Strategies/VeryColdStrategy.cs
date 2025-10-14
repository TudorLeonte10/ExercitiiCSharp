using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.Strategies
{
    internal class VeryColdStrategy : ITemperatureComparisonStrategy
    {
        public bool Matches(double currentTemp, double avgTemp)
            => currentTemp < avgTemp && (avgTemp - currentTemp > 10);

        public string GetMessage() => "Foarte rece";
    }
}
