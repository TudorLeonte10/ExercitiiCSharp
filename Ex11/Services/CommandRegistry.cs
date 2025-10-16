using Ex11.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Services
{
    public static class CommandRegistry
    {
        public static Dictionary<string, ICommand> Build(MeetingManager manager, IUserInterface ui)
        {
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            var commands = new Dictionary<string, ICommand>();
            foreach (var type in commandTypes)
            {
                var command = (ICommand)Activator.CreateInstance(type, manager, ui)!;
                commands[command.Name.ToLower()] = command;
            }

            return commands;
        }
    }
}
