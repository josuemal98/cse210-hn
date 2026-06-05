using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double total = 0;

            foreach (Product product in _products)
            {
                total += product.GetTotalProductPrice();
            }

            if (_customer.IsInUSA())
            {
                total += 5;
            }
            else
            {
                total += 35;
            }

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in _products)
            {
                label += $"- Product: {product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += $"{_customer.GetCustomerName()}\n{_customer.GetCustomerAddress()}\n";
            return label;
        }
    }
}