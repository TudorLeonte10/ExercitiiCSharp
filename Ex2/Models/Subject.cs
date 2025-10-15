using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models
{
    public class Subject
    {
        public string Name { get; set; } = string.Empty;
        public List<double> Grades { get; set; } = new();

        public override string ToString()
        {
            return $"{Name} ({string.Join(", ", Grades)})";
        }
    }
}
