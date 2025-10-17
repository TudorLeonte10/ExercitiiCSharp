using Ex17.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex17.Services;
using Ex17.Interfaces;

namespace Ex17.Services
{
    public class CommandRegistry
    {
        public static Dictionary<string,ICommand> Build(TicketManager ticket, IUserInterface userInterface)
        {
            var commanadTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            var commands = new Dictionary<string, ICommand>();
            foreach (var type in commanadTypes)
            {
                var command = (ICommand)Activator.CreateInstance(type, ticket, userInterface)!;
                commands[command.Name] = command;
            }
            return commands;
        }
    }
}
