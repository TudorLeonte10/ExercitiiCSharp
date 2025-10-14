namespace Ex19
{
    internal class BorrowRecord
    {
        public Person Person { get; }
        public LibraryItem Item { get; }
        public DateTime BorrowedDate { get; }
        public DateTime? ReturnedDate { get; private set; }

        public BorrowRecord(Person person, LibraryItem item)
        {
            Person = person;
            Item = item;
            BorrowedDate = DateTime.Now;
        }

        public void MarkReturned()
        {
            ReturnedDate = DateTime.Now;
        }

        public bool IsOverdue() => !ReturnedDate.HasValue && (DateTime.Now - BorrowedDate).TotalDays > 14;

        public override string ToString()
        {
            string status = ReturnedDate == null
                ? (IsOverdue() ?  "Intarziata" : "Imprumutata")
                : $"Returnata la {ReturnedDate:dd.MM.yyyy}";
            return $"{Person.Name} → {Item.Title} ({status})";
        }
    }
}
