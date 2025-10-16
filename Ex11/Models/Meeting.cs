using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string PersonA { get; set; } = string.Empty;
        public string PersonB { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public bool ConfirmedByA { get; set; }
        public bool ConfirmedByB { get; set; }

        public bool IsConfirmed => ConfirmedByA && ConfirmedByB;

        public override string ToString()
        {
            string confirmed = IsConfirmed ? "Confirmed" : "Pending";
            return $"{Id,3} | {PersonA,-10} & {PersonB,-10} | {DateTime:yyyy-MM-dd HH:mm} | {confirmed}";
        }
    }
}
