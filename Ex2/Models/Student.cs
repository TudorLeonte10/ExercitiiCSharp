using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<Subject> Subjects { get; set; } = new();

        public override string ToString()
        {
            return $"{Name} - {Subjects.Count} subjects";
        }
    }
}
