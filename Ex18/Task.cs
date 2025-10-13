namespace Ex18
{
    internal class Taskus
    {
        private static int nextId = 1;  

        public int Id { get; }
        public string Title { get; private set; }
        public bool IsDone { get; private set; }

        public Taskus(string title)
        {
            Id = nextId++;   
            Title = title;
            IsDone = false;
        }

        public void EditTitle(string title)
        {
            Title = title;
        }

        public void EditTaskCompletion(bool isDone)
        {
            IsDone = isDone;
        }

        public override string ToString() 
        { 
            return ($"{Id}.{Title} -- Is completed: {IsDone}"); 
        }
    }
}
