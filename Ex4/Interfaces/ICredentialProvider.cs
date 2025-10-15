using Ex4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.Interfaces
{
    public interface ICredentialProvider
    {
        IEnumerable<User> GetUsers();
    }
}
