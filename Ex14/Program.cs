using Ex14;
using Ex14.Services;
using System;

public class Program
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUserInterface();
        var service = new BankService();
        var manager = new AccountManager(ui,service);

        manager.Run();
    }
}