using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private const string Name_Msg = "Name cannot be empty";
        private const string Money_Msg = "Money cannot be negative";

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Name_Msg);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Money_Msg);
                }
                this.cost = value;
            }
        }
    }
}
