using Ex18.Models;
using Ex18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex18.Services
{
    public class AddTaskCommand : ICommand
    {
        public string Name => "add";
        private readonly TaskManager _manager;

        public AddTaskCommand(TaskManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            string title = _manager.UI.GetInput("Enter task title: ");
            string desc = _manager.UI.GetInput("Enter description: ");

            var task = new ToDoTask { Title = title, Description = desc };
            _manager.Repository.Add(task);
            _manager.UI.ShowMessage("Task added successfully.");
        }
    }
}
