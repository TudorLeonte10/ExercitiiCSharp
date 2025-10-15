using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._1.Models
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }   

        public virtual void StartEngine()
        {
            Console.WriteLine("The vehicle engine starts");
        }

        public override string ToString()
        {
            return $"{Brand} {Model} {Year}";
        }
    }
}
