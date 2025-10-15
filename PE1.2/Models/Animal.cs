using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._2.Models
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime IntakeDate { get; set; }

        public abstract void Speak();
        public virtual decimal DailyCareCost() => 5m;

        public override string ToString()
        {
            return $"{Id,-3} | {GetType().Name,-8} | {Name,-10} | {Age,-3} | {DailyCareCost(),6:C2}";
        }
    }
}
