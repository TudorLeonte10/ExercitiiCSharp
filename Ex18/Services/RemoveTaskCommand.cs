using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex18.Interfaces;

namespace Ex18.Services
{
    public class RemoveTaskCommand : ICommand
    {
        public string Name => "remove";
        private readonly TaskManager _manager;

        public RemoveTaskCommand(TaskManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            if (!_manager.Repository.GetAll().Any())
            {
                _manager.UI.ShowMessage("No tasks available to remove.");
                return;
            }

            string idInput = _manager.UI.GetInput("Enter task ID to remove: ");
            if (int.TryParse(idInput, out int id))
            {
                _manager.Repository.Remove(id);
                _manager.UI.ShowMessage("Task removed successfully.");
            }
            else
            {
                _manager.UI.ShowMessage(" Invalid ID.");
            }
        }
    }

}
