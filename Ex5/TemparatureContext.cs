using Ex5.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.Strategies
{
    internal class TemperatureContext
    {
        private readonly List<ITemperatureComparisonStrategy> _strategies;

        public TemperatureContext()
        {
            _strategies = new List<ITemperatureComparisonStrategy>
            {
                new SlightlyWarmerStrategy(),
                new VeryHotStrategy(),
                new SlightlyColderStrategy(),
                new VeryColdStrategy(),
                new EqualTemperatureStrategy()
            };
        }

        public string Evaluate(double currentTemp, double avgTemp)
        {
            var strategy = _strategies.FirstOrDefault(s => s.Matches(currentTemp, avgTemp));
            return strategy?.GetMessage() ?? "Nedefinit";
        }
    }

}
