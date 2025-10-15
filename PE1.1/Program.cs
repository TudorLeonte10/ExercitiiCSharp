using PE1._1;
using PE1._1.Models;

namespace VehicleManagement
{
    internal class Program
    {
        static readonly List<Vehicle> vehicles = new();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Vehicle Management System ===");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. List Vehicles");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        VehicleFactory.ListRegisteredVehicles();
                        Console.Write("Enter vehicle type: ");
                        var type = Console.ReadLine();
                        var v = VehicleFactory.CreateVehicle(type ?? "");
                        if (v != null) vehicles.Add(v);
                        break;

                    case "2":
                        ListVehicles();
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Program exited successfully!");
        }

        static void ListVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found.");
                return;
            }

            foreach (var v in vehicles)
            {
                Console.WriteLine($"\nType: {v.GetType().Name}");
                Console.WriteLine(v.ToString());
                v.StartEngine();

                if (v is IDriveable driveable)
                    driveable.Drive();
            }
        }
    }
}
