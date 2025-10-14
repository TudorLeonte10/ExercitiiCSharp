using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.Strategies
{

        internal interface ITemperatureComparisonStrategy
        {
            bool Matches(double currentTemp, double avgTemp);
            string GetMessage();
        }

}