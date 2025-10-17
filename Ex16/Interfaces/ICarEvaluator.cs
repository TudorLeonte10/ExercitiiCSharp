using Ex16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16.Interfaces
{
    public interface ICarEvaluator
    {
        string DetermineRablaCategory(Car car);
    }
}
