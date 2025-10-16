using Ex4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.Services
{
    public class BasicUserValidator : IUserValidator
    {
        private readonly ICredentialProvider _provider;

        public BasicUserValidator(ICredentialProvider provider)
        {
            _provider = provider;
        }

        public bool Validate(string username, string password)
        {
            return _provider.GetUsers()
                .Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                       && u.Password == password);
        }
    }
}
