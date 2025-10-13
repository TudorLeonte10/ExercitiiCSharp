using Ex16;
using System;

public class Program
{
    static void Main()
    {
        var car1 = new Car ("Dacia Logan", 2023, EngineType.Gas, 25000, 5.5, 130);
        var car2 = new Car ("Dacia Spring", 2023, EngineType.Electric, 30000, 0, 0);
        var car3 = new Car ("Dacia Duster", 2023, EngineType.Diesel, 35000, 6.5, 160);
        var car4 = new Car ("Dacia Sandero", 2023, EngineType.LPG, 28000, 5.0, 140);

        Console.WriteLine($"Masina {car1.Model} eligibila pentru rabla: {RablaRules.IsEligible(car1)}");
        Console.WriteLine($"Masina {car2.Model} eligibila pentru rabla: {RablaRules.IsEligible(car2)}");
        Console.WriteLine($"Masina {car3.Model} eligibila pentru rabla: {RablaRules.IsEligible(car3)}");
        Console.WriteLine($"Masina {car4.Model} eligibila pentru rabla: {RablaRules.IsEligible(car4)}");
    }
}