using ShoppingSpree.v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.v2.Core
{
    public class Engine
    {
        private ICollection<Person> people;
        private ICollection<Product> products;
        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                this.ParsePeopleInput();

                this.ParseProductsInput();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = splitted[0];
                    string productName = splitted[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] splitted = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string personStr in splitted)
            {
                string[] personArgs = personStr.Split("=");

                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }
        private void ParseProductsInput()
        {
            string[] splitted = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string productStr in splitted)
            {
                string[] productArgs = productStr.Split("=");

                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }
    }
}
