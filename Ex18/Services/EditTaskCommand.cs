using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex18.Interfaces;

namespace Ex18.Services
{
    public class EditTaskCommand : ICommand
    {
        public string Name => "edit";
        private readonly TaskManager _manager;

        public EditTaskCommand(TaskManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            string idInput = _manager.UI.GetInput("Enter task ID to edit: ");
            if (!int.TryParse(idInput, out int id))
            {
                _manager.UI.ShowMessage("⚠️ Invalid ID.");
                return;
            }

            var task = _manager.Repository.GetAll().FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                _manager.UI.ShowMessage("Task not found.");
                return;
            }

            string newTitle = _manager.UI.GetInput($"New title (leave empty to keep '{task.Title}'): ");
            string newDesc = _manager.UI.GetInput($"New description (leave empty to keep '{task.Description}'): ");
            string completed = _manager.UI.GetInput("Is completed? (y/n): ");

            if (!string.IsNullOrWhiteSpace(newTitle)) task.Title = newTitle;
            if (!string.IsNullOrWhiteSpace(newDesc)) task.Description = newDesc;
            task.IsCompleted = completed.Trim().ToLower() == "y";

            _manager.Repository.Update(task);
            _manager.UI.ShowMessage("✏️ Task updated successfully.");
        }
    }
}
