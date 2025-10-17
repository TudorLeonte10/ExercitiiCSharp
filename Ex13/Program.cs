using Ex13.Interfaces;
using Ex13.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

internal class Program
{
    static void Main()
    {
        IUserInterface ui = new ConsoleUserInterface();
        ISalaryCalculator calc = new BasicSalaryCalculator();
        var manager = new PayrollManager(ui, calc);

        manager.Run();
    }
}

