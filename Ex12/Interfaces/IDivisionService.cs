using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Interfaces
{
    public interface IDivisionService
    {
        public decimal Divide(decimal numerator, decimal denominator, int decimals = 2);
    }
}
