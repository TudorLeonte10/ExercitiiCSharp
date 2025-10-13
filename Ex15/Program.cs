using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Ex15;
public class Program
{
    static void Main(string[] args)
    {
        var product1 = new Product("Laptop", 4500.99, 10);
        var product2 = new Product("Mouse", 150.50, 50);
        var product3 = new Product("Keyboard", 300.75, 30);
        var product4 = new Product("Monitor", 1200.00, 20);

        var inventory = new Inventory();
        inventory.AddProduct(product1);
        inventory.AddProduct(product2);
        inventory.AddProduct(product3);
        inventory.AddProduct(product4);
        inventory.RemoveProduct(product2, 10);
        inventory.DisplayStock();
        Console.WriteLine($"Total stock value: {inventory.StockValue()}");
    }
}