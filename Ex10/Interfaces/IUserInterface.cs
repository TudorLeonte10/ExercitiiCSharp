using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Interfaces
{
    public interface IUserInterface
    {
        void ShowMessage(string message);
        string GetInput(string message);
    }
}
