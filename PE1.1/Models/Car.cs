using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._1.Models
{
    public class Car : Vehicle, IDriveable
    {
        public int NumberOfDoors { get; set; }

        public void Drive()
        {
            Console.WriteLine("We drivin the car");
        }

        public override void StartEngine()
        {
            Console.WriteLine("The car engine starts with a key");
        }

        public override string ToString()
        {
            return base.ToString() + NumberOfDoors;
        }
    }
}
