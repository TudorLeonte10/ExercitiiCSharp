using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public class Holiday
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public override string ToString() => $"{Date:dd MMM} - {Name}";
    }
}
