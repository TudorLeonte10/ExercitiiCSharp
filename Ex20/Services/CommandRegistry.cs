using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ex20.Interfaces;


namespace Ex20.Services
{
    public static class CommandRegistry
    {
        public static Dictionary<string, ICommand> Build(AttendanceManager manager)
        {
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            var commands = new Dictionary<string, ICommand>();
            foreach (var type in commandTypes)
            {
                var command = (ICommand)Activator.CreateInstance(type, manager)!;
                commands[command.Name.ToLower()] = command;
            }

            return commands;
        }
    }
}
