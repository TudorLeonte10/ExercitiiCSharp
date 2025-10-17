using Ex14.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14.Services
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
