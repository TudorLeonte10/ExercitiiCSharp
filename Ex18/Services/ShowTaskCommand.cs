using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex18.Interfaces;

namespace Ex18.Services
{
    public class ShowTasksCommand : ICommand
    {
        public string Name => "show";
        private readonly TaskManager _manager;

        public ShowTasksCommand(TaskManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            var tasks = _manager.Repository.GetAll();
            if (!tasks.Any())
            {
                _manager.UI.ShowMessage(" No tasks yet.");
                return;
            }

            _manager.UI.ShowMessage("\n To-Do List:");
            _manager.UI.ShowMessage(" ID | Title                | Status     | Description");
            _manager.UI.ShowMessage("----+----------------------+------------+-----------------------");
            foreach (var t in tasks)
            {
                _manager.UI.ShowMessage(t.ToString());
            }
        }
    }
}
