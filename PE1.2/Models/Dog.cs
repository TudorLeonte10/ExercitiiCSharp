using PE1._2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._2.Models
{
    public class Dog : Animal, IFeedable
    {
        public bool IsTrained { get; set; }

        public override void Speak() => Console.WriteLine($"{Name} says: Woof!");

        public override decimal DailyCareCost() => base.DailyCareCost() + 3m;

        public void Feed() => Console.WriteLine($"Dog {Name} has been fed.");

        public override string ToString() =>
            base.ToString() + $" | Trained: {(IsTrained ? "Yes" : "No")}";
    }
}
