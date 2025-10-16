using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9.Models
{
    public class CurrencyRate
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} | {Currency} | {Rate}";
        }
    }
}
