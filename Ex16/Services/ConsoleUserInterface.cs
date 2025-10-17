using Ex16.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16.Services
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
