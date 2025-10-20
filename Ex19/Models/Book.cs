using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Models
{
    public class Book : LibraryItem
    {
        public int Pages { get; set; }
        public override string GetItemType() => "Book";
    }
}
