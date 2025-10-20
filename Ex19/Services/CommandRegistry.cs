using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex19.Interfaces;

namespace Ex19.Services
{
    public static class CommandRegistry 
    {
        public static Dictionary<string, ICommand> Build(IBookService bookService, IUserInterface ui)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
                
            var commands = new Dictionary<string, ICommand>();
            foreach (var type in types)
            {
                var command = (ICommand)Activator.CreateInstance(type, bookService, ui)!;
                commands[command.Name] = command;
            }

            return commands;
        }


    }
}
