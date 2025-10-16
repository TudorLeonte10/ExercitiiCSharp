
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ex15;
internal class Program
{
    static void Main()
    {
        var inventory = new ProductInventory();
        var commands = CommandRegistry.GetCommands();
        var executor = new StockCommandExecutor(commands);

        executor.Add(inventory, new Product("Laptop", 3000m, 2));
        executor.Add(inventory, new Product("Mouse", 100m, 5));
        executor.Remove(inventory, new Product("Mouse", 0m, 0));

        inventory.ListProducts();
    }
}
