using Ex19;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Library library = new Library();

while (true)
{
    Console.WriteLine("\n MENIU BIBLIOTECA");
    Console.WriteLine("1. Adauga carte");
    Console.WriteLine("2. Adauga revista");
    Console.WriteLine("3. Afiseaza inventarul");
    Console.WriteLine("4. Imprumuta carte/revista");
    Console.WriteLine("5. Returneaza carte/revista");
    Console.WriteLine("6. Afiseaza istoricul imprumuturilor");
    Console.WriteLine("7. Afiseaza persoanele cu intarzieri");
    Console.WriteLine("0. Iesire");
    Console.Write("Alege optiunea: ");

    string? opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            Console.Write("Titlul cartii: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Autorul: ");
            string author = Console.ReadLine() ?? "";
            library.AddBook(title, author);
            break;

        case "2":
            Console.Write("Titlul revistei: ");
            string magTitle = Console.ReadLine() ?? "";
            Console.Write("Numarul editiei: ");
            int issue = int.TryParse(Console.ReadLine(), out var i) ? i : 0;
            library.AddMagazine(magTitle, issue);
            break;

        case "3":
            library.ListItems();
            break;

        case "4":
            Console.Write("Numele persoanei: ");
            string personName = Console.ReadLine() ?? "";
            Console.Write("Titlul itemului: ");
            string borrowTitle = Console.ReadLine() ?? "";
            library.BorrowItem(personName, borrowTitle);
            break;

        case "5":
            Console.Write("Numele persoanei: ");
            string returnName = Console.ReadLine() ?? "";
            Console.Write("Titlul itemului: ");
            string returnTitle = Console.ReadLine() ?? "";
            library.ReturnItem(returnName, returnTitle);
            break;

        case "6":
            library.ShowHistory();
            break;

        case "7":
            library.ShowOverdue();
            break;

        case "0":
            Console.WriteLine("Program inchis. La revedere!");
            return;

        default:
            Console.WriteLine("Optiune invalida, incearca din nou.");
            break;
    }
}
