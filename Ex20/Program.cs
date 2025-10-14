using Ex20;
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Introdu capacitatea maxima a cladirii: ");
        int capacity = int.Parse(Console.ReadLine());

        var system = new AttendanceSystem(capacity);

        while (true)
        {
            Console.WriteLine("1. Adauga angajat");
            Console.WriteLine("2. Inregistreaza prezenta");
            Console.WriteLine("3. Raport prezenta");
            Console.WriteLine("4. Iesire");
            Console.Write("Alege o optiune: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Nume angajat: ");
                    var name = Console.ReadLine();
                    system.AddEmployee(name);
                    break;
                case "2":
                    Console.Write("Nume angajat: ");
                    var empName = Console.ReadLine();
                    Console.Write("Data (dd.MM.yyyy): ");
                    var dateStr = Console.ReadLine();
                    if (DateTime.TryParseExact(dateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        system.AddAttendance(empName, date);
                    }
                    else
                    {
                        Console.WriteLine("Format data invalid.");
                    }
                    break;
                case "3":
                    system.AttendanceReport();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
    }
}