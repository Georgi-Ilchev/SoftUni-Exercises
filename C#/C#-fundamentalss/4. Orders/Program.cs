using System;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Product>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                string[] splittedInput = input.Split();

                string name = splittedInput[0];
                double price = double.Parse(splittedInput[1]);
                int quantity = int.Parse(splittedInput[2]);

                Product product = new Product(name, price, quantity);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
            }

            foreach (var pair in products)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Price * pair.Value.Quantity:f2}");
            }
        }

        class Product
        {
            string name;
            double price;
            int quantity;

            public Product(string name, double price, int quantity)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;
            }
            public double Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }
            public int Quantity
            {
                get
                {
                    return quantity;
                }
                set
                {
                    quantity = value;
                }
            }
        }
    }
}
