using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> peopleCollection = new List<Person>();
            List<Product> productCollection = new List<Product>();

            try
            {
                string[] people = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);
                    peopleCollection.Add(person);
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);

                    Product product = new Product(name, cost);
                    productCollection.Add(product);
                }

                string purchase = Console.ReadLine();

                while (purchase != "END")
                {
                    string[] splitted = purchase.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = splitted[0];
                    string currentProduct = splitted[1];

                    Person buyer = peopleCollection.FirstOrDefault(x => x.Name == name);
                    Product product = productCollection.FirstOrDefault(y => y.Name == currentProduct);

                    buyer.BuyProduct(product);

                    purchase = Console.ReadLine();
                }

                foreach (var item in peopleCollection)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
