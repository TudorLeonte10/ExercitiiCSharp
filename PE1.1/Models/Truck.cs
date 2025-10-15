using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._1.Models
{
    public class Truck : Vehicle, IDriveable
    {
        public double CargoCapacity { get; set; }

        public void Drive()
        {
            Console.WriteLine("We drivin the truck");
        }

        public override void StartEngine()
        {
            Console.WriteLine("The truck engine rumbles to life");
        }

        public override string ToString()
        {
            return base.ToString() + CargoCapacity;
        }
    }
}
