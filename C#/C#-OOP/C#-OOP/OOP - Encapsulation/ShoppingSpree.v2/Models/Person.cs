using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSpree.v2.Common;

namespace ShoppingSpree.v2.Models
{
    public class Person
    {
        private const string NOT_ENOUGH_MONEY_MSG = "{0} can't afford {1}";
        private const string SUCC_BOUGHT_PRODUCT_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
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
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
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
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMsg);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return (IReadOnlyCollection<Product>)this.bag; }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return string.Format(NOT_ENOUGH_MONEY_MSG, this.Name, product.Name);
            }

            this.Money -= product.Cost;
            this.bag.Add(product);

            return string.Format(SUCC_BOUGHT_PRODUCT_MSG, this.Name, product.Name);
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {productsOutput}";
        }
    }
}
