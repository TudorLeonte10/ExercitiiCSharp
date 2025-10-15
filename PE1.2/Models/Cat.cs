using PE1._2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._2.Models
{
    public class Cat : Animal, IFeedable
    {
        public bool IsIndoor { get; set; }

        public override void Speak() => Console.WriteLine($"{Name} says: Meow!");

        public override decimal DailyCareCost() => base.DailyCareCost() + 2m;

        public void Feed() => Console.WriteLine($"Cat {Name} has been fed.");

        public override string ToString() =>
            base.ToString() + $" | Indoor: {(IsIndoor ? "Yes" : "No")}";
    }
}
