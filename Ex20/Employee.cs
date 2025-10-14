using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20
{
    internal class Employee
    {
        public string Name { get; set; }
        public const int DaysRequired = 2;

        public Employee(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
