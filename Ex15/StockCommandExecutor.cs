
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
        private readonly Dictionary<StockAction, IStockCommand> _commands;

        public StockCommandExecutor(Dictionary<StockAction, IStockCommand> commands)
        {
            _commands = commands;
        }

        public void Add(ProductInventory inventory, Product product)
        {
            _commands[StockAction.Add].Execute(inventory, product);
        }

        public void Remove(ProductInventory inventory, Product product)
        {
            _commands[StockAction.Remove].Execute(inventory, product);
        }
    }
}
