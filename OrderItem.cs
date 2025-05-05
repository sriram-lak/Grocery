using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryBillingApp
{
    internal class OrderItem
    {
        // this property contain the id, name and price of product
        public Product Product { get; }
        // this property contain the quantity of product
        public int Quantity {  get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // calculate the total price of each item
        public double TotalPrice => Quantity * Product.Price;
    }
}
