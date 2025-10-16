using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1.Interfaces
{
    public interface IOperation
    {
        string Symbol { get; }
        double Execute(double a, double b);
    }
}
