using Ex12.Services;
using System;

public class Progam
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUserInterface();
        var service = new AccountingDivisionService();
        var manager = new DivisionManager(service, ui);

        manager.Run();
    }
}