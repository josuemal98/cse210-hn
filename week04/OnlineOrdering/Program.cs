using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Order order1 = new Order(customer1);
            
            order1.AddProduct(new Product("Laptop", "L102", 800.00, 1));
            order1.AddProduct(new Product("Mouse", "M501", 25.50, 2));

            Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("Keyboard", "K303", 45.00, 1));
            order2.AddProduct(new Product("Monitor", "MN88", 150.00, 2));
            order2.AddProduct(new Product("HDMI Cable", "C112", 12.99, 3));

            List<Order> orderList = new List<Order>();
            orderList.Add(order1);
            orderList.Add(order2);

            Console.WriteLine("--- ONLINE ORDERING REPORT ---\n");

            foreach (Order order in orderList)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
                Console.WriteLine("==================================================\n");
            }
        }
    }
}