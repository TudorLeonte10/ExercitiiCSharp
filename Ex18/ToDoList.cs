using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex18
{
    internal class ToDoList
    {
        private readonly List<Taskus> tasks = new();

        public void AddTask(Taskus task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);
            tasks.Remove(taskToRemove);
        }

        public void UpdateTaskName(int id, string title)
        {
            var taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToUpdate != null)
            {
                taskToUpdate.EditTitle(title);

            }
        }

        public void UpdateTaskCompletion(int id, bool isDone)
        {
            var taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToUpdate != null)
            {
                taskToUpdate.EditTaskCompletion(isDone);
            }
        }

        public void ListTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            Console.WriteLine(task);
        }

        public void ListAllTasks()
        {
            foreach (var task in tasks)
                Console.WriteLine(task);
        }

        
    }
}
