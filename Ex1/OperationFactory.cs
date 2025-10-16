using Ex1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public static class OperationFactory
    {
        private static readonly Dictionary<string, IOperation> _operations;

        static OperationFactory()
        {
            _operations = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IOperation).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (IOperation)Activator.CreateInstance(t)!)
                .ToDictionary(op => op.Symbol);
        }

        public static IOperation? GetOperation(string symbol)
        {
            _operations.TryGetValue(symbol, out var operation);
            return operation;
        }

        public static void ListAvailable()
        {
            Console.WriteLine("Available operations: " + string.Join(" ", _operations.Keys));
        }
    }
}
