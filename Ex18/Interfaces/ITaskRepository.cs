using Ex18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex18.Interfaces
{
    public interface ITaskRepository
    {
        List<ToDoTask> GetAll();
        void Add(ToDoTask task);
        void Remove(int id);
        void Update(ToDoTask task);
        void SaveChanges();
    }
}
