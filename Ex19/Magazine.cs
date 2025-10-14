namespace Ex19
{
    internal class Magazine : LibraryItem
    {
        public int IssueNumber { get; }

        public Magazine(string title, int issueNumber) : base(title)
        {
            IssueNumber = issueNumber;
        }

        public override string ToString()
        {
            return base.ToString() + $" — Editia #{IssueNumber}";
        }
    }
}
