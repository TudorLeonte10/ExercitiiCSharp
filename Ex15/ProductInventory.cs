namespace StockManagement.Core;

using StockManagement.Models;
using System.Collections.Generic;
using System.Linq;

public class ProductInventory
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product) => _products.Add(product);

    public void RemoveProduct(Product product)
    {
        _products.RemoveAll(p => p.Name == product.Name);
    }

    public decimal GetTotalValue() => _products.Sum(p => p.Price * p.Quantity);
}
