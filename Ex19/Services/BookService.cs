using Ex19.Interfaces;
using Ex19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19.Services
{
    public class BookService : IBookService
    {
        private readonly List<LibraryItem> _items = new();
        private readonly List<BorrowRecord> _borrowHistory = new();

        public void AddItem(LibraryItem item)
        {
            _items.Add(item);
        }

        public void BorrowItem(string title, string borrower)
        {
            var item = _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if(item != null && !item.IsBorrowed)
            {
                item.IsBorrowed = true;
                _borrowHistory.Add(new BorrowRecord
                {
                    BorrowedItemTitle = title,
                    PersonName = borrower,
                    BorrowDate = DateTime.Now
                });
            }
            else
            {
                throw new InvalidOperationException("Item is either not found or already borrowed.");
            }

        }

        public IEnumerable<LibraryItem> GetAllItems()
        {
            foreach(var item in _items)
            {
                yield return item;
            }
        }

        public List<BorrowRecord> GetBorrowHistory() => _borrowHistory;

        public void RemoveItem(string title)
        {
            var item = _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if(item != null)
            {
                _items.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("Item not found.");
            }
        }

        public void ReturnItem(string title, string personName)
        {
            var item = _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if(item != null && item.IsBorrowed)
            {
                item.IsBorrowed = false;
                var record = _borrowHistory.LastOrDefault(r => r.BorrowedItemTitle.Equals(title, StringComparison.OrdinalIgnoreCase)
                                                            && r.PersonName.Equals(personName, StringComparison.OrdinalIgnoreCase)
                                                            && r.ReturnDate == null);
                if (record != null)
                {
                    record.ReturnDate = DateTime.Now;
                }
            }
            else
            {
                throw new InvalidOperationException("Item is either not found or not borrowed.");
            }
        }
    }
}
