
using StockManagement.Models;
using System.Collections.Generic;
using System.Linq;

public class ProductInventory
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Name == product.Name);
        if (existing != null)
            existing.Quantity += product.Quantity;
        else
            _products.Add(product);
    }

    public void RemoveProduct(string name)
    {
        var existing = _products.FirstOrDefault(p => p.Name == name);
        if (existing != null)
            _products.Remove(existing);
    }

    public void ListProducts()
    {
        if (!_products.Any())
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("\nCurrent inventory:");
        foreach (var p in _products)
            Console.WriteLine(p);
    }
}
