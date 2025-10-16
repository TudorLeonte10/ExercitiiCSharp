using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Interfaces
{
    public interface IYearRule
    {
        string Description { get; }
        bool Evaluate(int year);
    }
}
