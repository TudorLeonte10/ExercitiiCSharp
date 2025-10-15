using Ex18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex18.Services
{
    public class TaskManager
    {
        public readonly ITaskRepository Repository;
        public readonly IUserInterface UI;

        public TaskManager(ITaskRepository repository, IUserInterface ui)
        {
            Repository = repository;
            UI = ui;
        }
    }
}
