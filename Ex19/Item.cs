using System;

namespace Ex19
{
    internal abstract class LibraryItem
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Title { get; }
        public bool IsBorrowed { get; private set; }
        public Person? BorrowedBy { get; private set; }
        public DateTime? BorrowedDate { get; private set; }

        protected LibraryItem(string title)
        {
            Id = nextId++;
            Title = title;
        }

        public void Borrow(Person person)
        {
            if (IsBorrowed)
            {
                Console.WriteLine($"{Title} este deja imprumutata de {BorrowedBy?.Name}.");
                return;
            }

            IsBorrowed = true;
            BorrowedBy = person;
            BorrowedDate = DateTime.Now;
            Console.WriteLine($"{Title} a fost imprumutata de {person.Name} la {BorrowedDate:dd.MM.yyyy}");
        }

        public void Return()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine($"{Title} nu este imprumutata.");
                return;
            }

            Console.WriteLine($"{Title} a fost returnata de {BorrowedBy?.Name}.");
            IsBorrowed = false; 
            BorrowedBy = null;
            BorrowedDate = null;
        }

        public override string ToString()
        {
            string status = IsBorrowed
                ? $"(Imprumutata de {BorrowedBy?.Name} la {BorrowedDate:dd.MM.yyyy})"
                : "(Disponibila)";
            return $"{Id}. {Title} {status}";
        }
    }
}
