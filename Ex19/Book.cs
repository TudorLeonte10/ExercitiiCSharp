namespace Ex19
{
    internal class Book : LibraryItem
    {
        public string Author { get; }

        public Book(string title, string author) : base(title)
        {
            Author = author;
        }

        public override string ToString()
        {
            return base.ToString() + $" — Autor: {Author}";
        }
    }
}
