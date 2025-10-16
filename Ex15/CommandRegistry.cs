using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public static class CommandRegistry
    {
        public static Dictionary<StockAction, IStockCommand> GetCommands()
        {
            return new Dictionary<StockAction, IStockCommand>
            {
                { StockAction.Add, new AddCommand() },
                { StockAction.Remove, new RemoveCommand() }
            };
        }
    }
}
