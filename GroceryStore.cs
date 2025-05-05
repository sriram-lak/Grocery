using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryBillingApp
{
    internal class GroceryStore
    {
        // it store the all product id, name and price
        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        // create the customer order class object is used for print the bill store the order and edit
        CustomerOrder customerOrder = new CustomerOrder();

        // initially declare the default product detail
        public GroceryStore()
        {
            products.Add(101, new Product(101, "Cake", 100.0));
            products.Add(102, new Product(102, "Jam", 200.0));
            products.Add(103, new Product(103, "Candys", 10.0));
        }
        
        // customer take the order
        public void Start()
        {
            // List all product
            Console.WriteLine("Product List : \n");
            foreach(var product in products)
            {
                Console.WriteLine($"Product Id - {product.Value.Id}\tProduct Name - {product.Value.Name}\tProduct Price - {product.Value.Price}");
            }
            Console.WriteLine("Press 1 : Order the Product \nPress Any Key : Close App");
            bool isContinue = (Console.ReadLine() == "1") ? true : false;
            while(isContinue)
            {
                Product product = SelectProduct();
                int quantity = CheckQuantity();
                customerOrder.AddOrUpdate(product, quantity);
                Console.WriteLine("Type \"bill\" : Close the Order \nPress Any Key : Continue the order");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "bill")
                {
                    isContinue = false;
                }
            }
            customerOrder.PrintBill();
        }

        // this method used for valid product id calculate
        public Product SelectProduct()
        {
            int id;
            while (true)
            {
                Console.WriteLine("Enter the Product Id");
                if (int.TryParse(Console.ReadLine(), out id) && products.ContainsKey(id))
                {
                    if (customerOrder.HasItem(id))
                    {
                        Console.WriteLine($"You have already Order the item {products[id].Name} and Quantity is {customerOrder.Quantity(id)}");
                        Console.WriteLine("Press 1 : Ok Continue to add Quantity \nPress Any Key : skip");
                        if (Console.ReadLine() == "1")
                        {
                            return products[id];
                        }
                    }
                    else
                    {
                        return products[id];
                    }
                }
                Console.WriteLine("Please Enter the Valid Product Id");
            }
        }

        // this method is used for check the valid quantity
        public static int CheckQuantity()
        {
            int quantity;
            while (true)
            {
                Console.WriteLine("Enter the Number of product");
                // Quantity is interger and greater than zero
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    return quantity;
                }
                Console.WriteLine("Please Enter the Positive number of Quantity");
            }
        }
    }
}
