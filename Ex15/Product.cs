namespace StockManagement.Models;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
         return $"{Name,-10} | {Price,8:C} | Qty: {Quantity}";
    }
}
