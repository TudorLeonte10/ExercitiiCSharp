using Ex3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Services
{
    public class LeapYearRule : IYearRule
    {
        public string Description => "Leap year rule (divisible by 4, except centuries not divisible by 400)";

        public bool Evaluate(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
