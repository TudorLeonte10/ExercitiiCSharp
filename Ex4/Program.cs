using Ex4.Interfaces;
using Ex4.Services;
using System;

internal class Program
{
    static void Main()
    {
        ICredentialProvider provider = new InMemoryCredentialProvider();
        IUserValidator validator = new BasicUserValidator(provider);
        var loginManager = new LoginManager(validator);

        Console.WriteLine(" Auth\n");
        loginManager.Authenticate();
    }
}