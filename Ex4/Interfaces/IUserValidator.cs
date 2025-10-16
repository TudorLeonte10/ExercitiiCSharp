using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.Interfaces
{
    public interface IUserValidator
    {
        bool Validate(string username, string password);
    }

}
