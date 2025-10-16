using Ex18.Interfaces;
using Ex18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ex18.Repositories
{
    public class JsonTaskRepository : ITaskRepository
    {
        private readonly string _filePath = "tasks.json";
        private List<ToDoTask> _tasks = new();

        public JsonTaskRepository()
        {

            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _tasks = JsonSerializer.Deserialize<List<ToDoTask>>(json) ?? new();
            }
        }
        public List<ToDoTask> GetAll() => _tasks;

        public void Add(ToDoTask task)
        {
            task.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
            SaveChanges();
        }

        public void Remove(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                SaveChanges();
            }
        }

        public void Update(ToDoTask task)
        {
            var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.IsCompleted = task.IsCompleted;
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
    
}
