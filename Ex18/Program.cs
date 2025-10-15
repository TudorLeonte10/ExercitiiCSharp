using System;

namespace Ex18 {
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To-do-list misto");
            Console.WriteLine("Scrie 'help' pentru ca sa vezi comenzile");

            var toDoList = new ToDoList();

            while (true)
            {
                string? input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "add":
                        Console.WriteLine("Introdu titlul sarcinii:");
                        string? titlu = Console.ReadLine()?.Trim();
                        var task = new Taskus(titlu);
                        toDoList.AddTask(task);
                        Console.WriteLine("Task adaugat cu succes");
                        break;
                    case "delete":
                        Console.WriteLine("Introdu id-ul sarcinii pe care vrei sa o stergi");
                        int.TryParse(Console.ReadLine()?.Trim(), out var id);
                        toDoList.RemoveTask(id);
                        Console.WriteLine("Task sters cu succes"); 
                        break;
                    case "edit":
                        Console.WriteLine("Introdu id-ul sarcinii pe care vrei sa o editezi");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine("Ce vrei sa editezi? Apasa 't' pentru titlu, 'c' pentru a modifica finalitatea task-ului");
                        string? letter = Console.ReadLine()?.Trim();

                        if (letter == "t")
                        {
                            Console.WriteLine("Scrie titlul nou");
                            string? title = Console.ReadLine()?.Trim();
                            toDoList.UpdateTaskName(id, title);
                        }
                        else if (letter == "c")
                        {
                            Console.WriteLine("Scrie 'done' pentru a marca task-ul ca finalizat si orice altceva ca sa marchezi ca nefinalizat");

                            if (Console.ReadLine() == "done")
                            {
                                toDoList.UpdateTaskCompletion(id, true);
                            }
                            else
                            {
                                toDoList.UpdateTaskCompletion(id, false);
                            }
                            Console.WriteLine("Task editat cu succes");
                        }
                        break;
                    case "list":
                        toDoList.ListAllTasks();
                        break;
                    case "help":
                        Console.WriteLine("\nComenzi disponibile:");
                        Console.WriteLine(" add               -> adauga o sarcina");
                        Console.WriteLine(" list              -> afisează toate sarcinile");
                        Console.WriteLine(" edit              -> modifica titlul unei sarcini");
                        Console.WriteLine(" delete            -> sterge o sarcina");
                        Console.WriteLine(" help              -> afiseaza comenzi");
                        Console.WriteLine(" exit              -> închide aplicatia");
                        break;
                    case "exit":
                        return;
                }
            }
        }
    }
}