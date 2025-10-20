using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Models
{
    public abstract class LibraryItem
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public bool IsBorrowed { get; set; } = false;

        public abstract string GetItemType();
        public override string ToString()
        {
            return $"{GetItemType()}: {Title} by {Author}, {Year}";
        }
    }
}
