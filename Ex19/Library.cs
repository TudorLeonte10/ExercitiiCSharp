namespace Ex19
{
    internal class Library
    {
        private readonly List<LibraryItem> _items = new();
        private readonly List<Person> _people = new();
        private readonly List<BorrowRecord> _history = new();

        public void AddBook(string title, string author)
        {
            _items.Add(new Book(title, author));
            Console.WriteLine($"Carte adaugata: {title}");
        }

        public void AddMagazine(string title, int issue)
        {
            _items.Add(new Magazine(title, issue));
            Console.WriteLine($"Revista adaugata: {title}");
        }

        public void ListItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Biblioteca este goala.");
                return;
            }

            Console.WriteLine("\n Inventar curent:");
            foreach (var item in _items)
                Console.WriteLine(" " + item);
        }

        public void BorrowItem(string personName, string title)
        {
            var person = _people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                _people.Add(person);
            }

            var item = _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                Console.WriteLine("Itemul nu exista in biblioteca.");
                return;
            }

            person.Borrow(item);

            _history.Add(new BorrowRecord(person, item));
        }


        public void ReturnItem(string personName, string title)
        {
            var person = _people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                Console.WriteLine("Persoana nu exista în sistem.");
                return;
            }

            var item = _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                Console.WriteLine("Itemul nu exista.");
                return;
            }

            person.Return(item);
        }

        public void ShowOverdue()
        {
            var overdue = _history.Where(r => r.IsOverdue()).ToList();
            if (overdue.Count == 0)
            {
                Console.WriteLine("Nicio carte întarziata.");
                return;
            }

            Console.WriteLine("\n Persoane cu imprumuturi intarziate:");
            foreach (var r in overdue)
                Console.WriteLine($" - {r.Person.Name} (carte: {r.Item.Title}, din {r.BorrowedDate:dd.MM})");
        }

        public void ShowHistory()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("Nicio inregistrare de imprumuturi.");
                return;
            }

            Console.WriteLine("\nIstoric imprumuturi:");
            foreach (var r in _history)
                Console.WriteLine(" " + r);
        }
    }
}
