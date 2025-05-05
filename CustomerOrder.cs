using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GroceryBillingApp
{
    internal class CustomerOrder
    {
        // this dictionary is stor the customer order detail 
        private Dictionary<int, OrderItem> orderItems = new Dictionary<int, OrderItem>();

        // this property used for help the customer all ready order the product or not
        public bool HasItem(int id) { return orderItems.ContainsKey(id); }
        // this property provide the number of quantity 
        public int Quantity(int id) { return orderItems[id].Quantity; }

        // it is handle the duplicate key 
        public void AddOrUpdate(Product product, int quantity)
        {
            if (orderItems.ContainsKey(product.Id))
            {
                orderItems[product.Id].Quantity += quantity;
            }
            else
            {
                orderItems[product.Id] = new OrderItem(product, quantity);
            }
        }

        // Display the customer order Bill
        public void PrintBill()
        {
            double totalAmount = 0;
            // Customer not add the item
            if (orderItems.Count == 0)
            {
                Console.WriteLine("Not Buy AnyThing");
            }
            // Display the Bill and Total Amount;
            else
            {
                foreach (KeyValuePair<int, OrderItem> customer in orderItems)
                {
                    Console.WriteLine($"Product Name - {customer.Value.Product.Name} \t Product Quantity - {customer.Value.Quantity} \t Amount - {customer.Value.TotalPrice}");
                    totalAmount += customer.Value.TotalPrice;
                }
                Console.WriteLine($"Total Amount of the Bill is : {totalAmount}");

                // Asking the Bill is edit or not
                Console.WriteLine("Press 1 : Edit Bill \nPress Any Key : Close App");
                if (Console.ReadLine() == "1")
                {
                    EditCustomerOrder();
                    PrintBill();
                }
            }
        }

        // this method is used to edit the bill
        public void EditCustomerOrder()
        {
            foreach (KeyValuePair<int, OrderItem> customer in orderItems)
            {
                // display the bill item and user can delete the item or change the product quantity
                Console.WriteLine($"Product Name - {customer.Value.Product.Name} \t Product Quantity - {customer.Value.Quantity} \t Amount - {customer.Value.TotalPrice}");
                Console.WriteLine($"Press 1 : Remove the Item {customer.Value.Product.Name} \nPress 2 : Change Quantity {customer.Value.Quantity} \nPress Any Key : No Change");
                string inputTestEdit = Console.ReadLine();
                // remove item
                if (inputTestEdit == "1")
                {
                    orderItems.Remove(customer.Key);
                }
                //Change Product quantity
                else if (inputTestEdit == "2")
                {
                    customer.Value.Quantity = GroceryStore.CheckQuantity();
                }
            }
        }
    }

}
