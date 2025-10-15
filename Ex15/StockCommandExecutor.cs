using StockManagement.Core;
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public class StockCommandExecutor
    {
        private readonly Dictionary<string, IStockCommand> _commands;

        public StockCommandExecutor(Dictionary<string, IStockCommand> commands)
        {
            _commands = commands;
        }

        public void Execute(string action, ProductInventory inventory, Product product)
        {
            _commands[action].Execute(inventory, product);
        }
    }
}
