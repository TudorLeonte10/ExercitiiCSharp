using Ex4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.Services
{
    public class LoginManager
    {
        private readonly IUserValidator _validator;
        private const int MaxAttempts = 3;

        public LoginManager(IUserValidator validator)
        {
            _validator = validator;
        }

        public void Authenticate()
        {
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = Console.ReadLine();

                if (_validator.Validate(username ?? "", password ?? ""))
                {
                    Console.WriteLine("Done!");
                    return;
                }

                attempts++;
                Console.WriteLine($"Invalid data. ({attempts}/{MaxAttempts})\n");
            }

            Console.WriteLine("Too many tries.");
        }
    }
}
