using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Models
{
    public class BorrowRecord
    {
        public string PersonName { get; set; } = string.Empty;
        public string BorrowedItemTitle { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }

        public bool IsOverdue() => !ReturnDate.HasValue && DateTime.Now > BorrowDate.AddDays(14);

        public override string ToString()
        {
            string status = ReturnDate.HasValue ? $"Returned on {ReturnDate.Value.ToShortDateString()}" : "Not returned yet";
            return $"{PersonName} borrowed '{BorrowedItemTitle}' on {BorrowDate.ToShortDateString()}. Status: {status}";
        }
    }
}
