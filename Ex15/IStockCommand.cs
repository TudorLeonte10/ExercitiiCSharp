
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public interface IStockCommand
    {
        void Execute(ProductInventory inventory, Product product);
    }
}
