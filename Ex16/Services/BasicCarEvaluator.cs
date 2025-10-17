using Ex16.Interfaces;
using Ex16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16.Services
{
    internal class BasicCarEvaluator : ICarEvaluator
    {
        public string DetermineRablaCategory(Car car)
        {
            int currentYear = DateTime.Now.Year;
            int carAge = currentYear - car.Year;

            if (car.EngineType.ToLower() == "electric")
                return "Not eligible for Rabla Classic (electric vehicles are already eco).";

            if (carAge > 15 || car.Emissions > 200)
                return "Eligible for Rabla Classic (old or polluting vehicle).";

            if (car.EngineType.ToLower() == "diesel" && car.Emissions > 150)
                return "Eligible for Rabla Plus with eco-bonus for replacing high-emission diesel.";

            if (car.EngineType.ToLower() == "hybrid" && car.Emissions < 100)
                return "Eco-friendly vehicle (not eligible for Rabla, already efficient).";

            return "Not eligible (vehicle too new or efficient for replacement).";
        }
    }
}
