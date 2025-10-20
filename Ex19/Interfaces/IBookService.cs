using Ex19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Interfaces
{
    public interface IBookService
    {
        void AddItem(LibraryItem item);
        void RemoveItem(string title);
        IEnumerable<LibraryItem> GetAllItems();
        void BorrowItem(string title, string borrower);
        void ReturnItem(string title, string personName);
        List<BorrowRecord> GetBorrowHistory();
    }
}
