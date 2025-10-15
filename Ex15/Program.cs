using StockManagement.Core;
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ex15;
class Program
{
    static void Main()
    {
        var inventory = new ProductInventory();

        var commands = new Dictionary<string, IStockCommand>
        {
            { "add", new AddCommand() },
            { "remove", new RemoveCommand() }
        };

        var executor = new StockCommandExecutor(commands);

        executor.Execute("add", inventory, new Product("Laptop", 3000m, 2));
        executor.Execute("add", inventory, new Product("Mouse", 100m, 5));
        executor.Execute("remove", inventory, new Product("Mouse", 0, 0));

        Console.WriteLine($"Valoare totală stoc: {inventory.GetTotalValue()} RON");
    }
}