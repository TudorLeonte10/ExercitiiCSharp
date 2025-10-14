namespace Ex19
{
    internal class Person
    {
        public string Name { get; }
        public List<BorrowRecord> BorrowedBooks { get; } = new();

        public Person(string name)
        {
            Name = name;
        }

        public void Borrow(LibraryItem item)
        {
            item.Borrow(this);
            BorrowedBooks.Add(new BorrowRecord(this, item));
        }

        public void Return(LibraryItem item)
        {
            item.Return();
            var record = BorrowedBooks.LastOrDefault(r => r.Item == item && r.ReturnedDate == null);
            record?.MarkReturned();
        }

        public override string ToString()
        {
            int active = BorrowedBooks.Count();
            return $"{Name} — {active} carti imprumutate";
        }
    }
}
