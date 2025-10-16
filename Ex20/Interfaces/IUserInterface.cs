using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Interfaces
{
    public interface IUserInterface
    {
        string GetInput(string message);
        void ShowMessage(string message);
    }
}
