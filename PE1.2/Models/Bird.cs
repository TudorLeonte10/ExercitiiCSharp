using PE1._2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._2.Models
{
     public class Bird : Animal, IFeedable, IFlyable
     {
            public double WingSpanCm { get; set; }

            public override void Speak() => Console.WriteLine($"{Name} says: Chirp!");

            public override decimal DailyCareCost() => base.DailyCareCost() + 1m;

            public void Feed() => Console.WriteLine($"Bird {Name} has been fed.");

            public void Fly() => Console.WriteLine($"Bird {Name} flaps wings of {WingSpanCm} cm.");

            public override string ToString() =>
                base.ToString() + $" | WingSpan: {WingSpanCm:F1} cm";
        }
    }

