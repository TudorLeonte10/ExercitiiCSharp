using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16
{
    internal class RablaRules
    {
        public const double PriceCapTermic = 60_000;
        public const double PriceCapElectric = 70_000;
        public const double Emissions = 145;

        public static bool IsEligible(Car car)
        {
            if (car.Engine == EngineType.Diesel)
                return false;
            else if (car.Engine == EngineType.Electric)
            {
                bool okPrice = car.Price < PriceCapElectric;
                if (okPrice)
                {
                    return true;
                }
            }
            else if ((car.Engine == EngineType.Gas || car.Engine == EngineType.LPG) && 
                      (car.Noxes <= Emissions))
            {
                bool okPrice = car.Price < PriceCapTermic;
                if (okPrice)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
