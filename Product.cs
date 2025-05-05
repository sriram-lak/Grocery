using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryBillingApp
{
    internal class Product
    {
        // product id
        public int Id { get; }
        // product name
        public string Name { get; }
        // product price
        public double Price { get; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
