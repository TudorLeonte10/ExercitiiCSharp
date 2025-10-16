using PE1._2.Interfaces;
using PE1._2.Models;
using System.Numerics;


namespace PetShelter
{
    internal class Program
    {
        private static readonly List<Animal> animals = new();
        private static int nextId = 1;

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Dog");
                Console.WriteLine("2. Add Cat");
                Console.WriteLine("3. Add Bird");
                Console.WriteLine("4. List Animals");
                Console.WriteLine("5. Feed All");
                Console.WriteLine("6. Speak All");
                Console.WriteLine("7. Adopt (by Id)");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDog(); break;
                    case "2": AddCat(); break;
                    case "3": AddBird(); break;
                    case "4": ListAnimals(); break;
                    case "5": FeedAll(); break;
                    case "6": SpeakAll(); break;
                    case "7": AdoptAnimal(); break;
                    case "8": exit = true; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        static void AddDog()
        {
            var dog = new Dog
            {
                Id = nextId++,
                Name = ReadNonEmpty("Enter name: "),
                Age = ReadInt("Enter age: ", min: 0),
                IsTrained = ReadBool("Is trained? (y/n): ")
            };
            animals.Add(dog);
            Console.WriteLine($"Dog {dog.Name} added!");
        }

        static void AddCat()
        {
            var cat = new Cat
            {
                Id = nextId++,
                Name = ReadNonEmpty("Enter name: "),
                Age = ReadInt("Enter age: ", min: 0),
                IsIndoor = ReadBool("Is indoor? (y/n): ")
            };
            animals.Add(cat);
            Console.WriteLine($"Cat {cat.Name} added!");
        }

        static void AddBird()
        {
            var bird = new Bird
            {
                Id = nextId++,
                Name = ReadNonEmpty("Enter name: "),
                Age = ReadInt("Enter age: ", min: 0),
                WingSpanCm = ReadDouble("Enter wingspan (cm): ", min: 0.1)
            };
            animals.Add(bird);
            Console.WriteLine($"Bird {bird.Name} added!");
        }

        static void ListAnimals()
        {
            if (!animals.Any())
            {
                Console.WriteLine("No animals in shelter.");
                return;
            }

            Console.WriteLine("\nID  | Type     | Name       | Age |  Cost | Extra");
            Console.WriteLine("----+----------+------------+-----+--------+-----------------------");
            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
                if (a is IFlyable flyable)
                    flyable.Fly();
            }
        }

        static void FeedAll()
        {
            int count = 0;
            foreach (var a in animals.OfType<IFeedable>())
            {
                a.Feed();
                count++;
            }
            Console.WriteLine($"\n {count} animals have been fed.");
        }

        static void SpeakAll()
        {
            if (!animals.Any())
            {
                Console.WriteLine("No animals to speak.");
                return;
            }

            Console.WriteLine("\nAnimal sounds:");
            foreach (var a in animals)
            {
                a.Speak();
            }
        }

        static void AdoptAnimal()
        {
            int id = ReadInt("Enter animal Id to adopt: ", min: 1);
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.");
                return;
            }

            animals.Remove(animal);
            Console.WriteLine($"{animal.Name} has been adopted!");
        }

        static string ReadNonEmpty(string message)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("Name cannot be empty.");
            }
        }

        static int ReadInt(string message, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out var val) && val >= min)
                    return val;
                Console.WriteLine($"Please enter a valid integer ≥ {min}.");
            }
        }

        static double ReadDouble(string message, double min = double.MinValue)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out var val) && val >= min)
                    return val;
                Console.WriteLine($"Please enter a valid number ≥ {min}.");
            }
        }

        static bool ReadBool(string message)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "y" || input == "yes") return true;
                if (input == "n" || input == "no") return false;
                Console.WriteLine("Please enter y/n.");
            }
        }
    }
}
