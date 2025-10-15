using Ex4.Interfaces;
using Ex4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.Services
{
    public class InMemoryCredentialProvider : ICredentialProvider
    {
        public IEnumerable<User> GetUsers() => new List<User>
        {
            new User("admin", "1234"),
            new User("tudor", "pass"),
            new User("guest", "guest")
        };
    }
}
