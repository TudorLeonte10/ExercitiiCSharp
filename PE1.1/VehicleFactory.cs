using PE1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PE1._1
{
    public static class VehicleFactory
    {
        private static readonly Dictionary<string, Type> _vehicleRegistry = new();

        static VehicleFactory()
        {
            var vehicleType = typeof(Vehicle);
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => vehicleType.IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var type in types)
            {
                _vehicleRegistry[type.Name.ToLower()] = type;
            }
        }

        public static Vehicle? CreateVehicle(string typeName)
        {
            if(!_vehicleRegistry.TryGetValue(typeName, out var type))
            {
                Console.WriteLine("Nu ai pus tipul corect");
                return null;
            }

            var vehicle = (Vehicle?)Activator.CreateInstance(type);
            if(vehicle == null)
                return null;

            foreach (var prop in type.GetProperties().Where(p => p.CanWrite && p.SetMethod.IsPublic == true) ){
                Console.WriteLine($"Enter {prop.Name}");

                var input = Console.ReadLine();

                try
                {
                    object? value = null;
                    if (prop.PropertyType == typeof(int))
                        value = int.Parse(input ?? "0");
                    else if (prop.PropertyType == typeof(double))
                        value = double.Parse(input ?? "0");
                    else if (prop.PropertyType == typeof(bool))
                        value = (input?.Trim().ToLower() == "y" || input?.Trim().ToLower() == "yes");
                    else
                        value = input ?? "";

                    prop.SetValue(vehicle, value);
                }
                catch
                {
                    Console.WriteLine($"Invalid value for {prop.Name}. Using default.");
                }
            }

            Console.WriteLine($"{type.Name} added successfully!");
            return vehicle;

        }

        public static void ListRegisteredVehicles()
        {
            Console.WriteLine("\nAvailable vehicle types:");
            foreach (var kvp in _vehicleRegistry)
            {
                Console.WriteLine($"- {kvp.Key}");
            }
        }

    }
}
