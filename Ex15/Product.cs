namespace StockManagement.Models;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
