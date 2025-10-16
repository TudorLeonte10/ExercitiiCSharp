using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9.Interfaces
{
    public interface ICurrencyConverter
    {
        decimal Convert(decimal amount, decimal rate);
    }
}
