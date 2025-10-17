using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16.Models
{
    public class Car
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string EngineType { get; set; } = string.Empty;
        public double Consumption { get; set; } 
        public double Emissions { get; set; }   

        public override string ToString()
        {
            return $"{Model} ({Year}) - Engine: {EngineType}, Consumption: {Consumption:F1} L/100km, CO₂: {Emissions:F1} g/km";
        }
    }
}
