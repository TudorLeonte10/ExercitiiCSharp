using Ex1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class MultiplyOperation : IOperation
    {
        public string Symbol => "*";
        public double Execute(double a, double b) => a * b;
    }
}
