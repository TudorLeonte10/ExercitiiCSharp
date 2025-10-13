using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16
{
    internal class Car
    {
        public string Model { get; set; }
        public int Make {  get; set; }
        public EngineType Engine {  get; set; }
        public double Price { get; set; }
        public double Consumption { get; set; }
        public double Noxes {  get; set; }

        public Car(string model, int make, EngineType engine, double price, double Consumption, double Noxes)
        {
            this.Model = model;
            this.Make = make;
            this.Engine = engine;
            this.Price = price;
            this.Consumption = Consumption;
            this.Noxes = Noxes;
        }
    }
}
