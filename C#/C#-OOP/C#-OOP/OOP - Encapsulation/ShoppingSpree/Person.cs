using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly ICollection<string> bagOfProducts;
        //private List<Product> bag;

        private Person()
        {
            //only initialize the list
            this.bagOfProducts = new List<string>();
        }

        public Person(string name, decimal money) : this()
        {
            //this.bagOfProducts = new List<string>();
            //this.bag = new List<Product>();
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<string> BagOfProducts { get { return(IReadOnlyCollection<string>) this.bagOfProducts; } }

        //public List<Product> Bag { get { return this.bag; } }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
                this.bagOfProducts.Add(product.Name);
            }
        }

        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.bagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                person += string.Join(", ", this.bagOfProducts);
            }
            return person;
        }
    }
}
