using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.Design;

namespace Ex15
{
    internal class Inventory
    {
        public Dictionary<Product, int> Products {  get; set; } = new();

        public void AddProduct(Product product)
        {
            var existentProduct = Products.FirstOrDefault(p => p.Key.Name.ToLower() == product.Name.ToLower());

            if (existentProduct.Key == null)
            {
                Products.Add(product, product.Quantity);
            }
            else
            {
                product.Quantity += 1;
            }
        }

        public void RemoveProduct(Product product, int quantity)
        {
            var existentProduct = Products.FirstOrDefault(p => p.Key.Name.ToLower() == product.Name.ToLower());

            if (existentProduct.Key != null && quantity == existentProduct.Value)
            {
                Products.Remove(product);
            }
            else if (existentProduct.Key != null && quantity <= existentProduct.Value)
            {
                Products[product] = Products[product] - quantity;
            }
        }

        public void DisplayStock()
        {
            foreach(var entry in Products)
            {
                Console.WriteLine(entry);
            }
        }

        public double StockValue()
        {
            double value = 0;
            foreach(var entry in Products)
            {
                value += entry.Key.Price * entry.Value;
            }
            return value;
        }

    }
}
