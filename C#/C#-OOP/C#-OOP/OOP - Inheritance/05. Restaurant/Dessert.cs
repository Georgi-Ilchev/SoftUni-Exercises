using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories)
            :base (name,price,grams)
        {
            this.Calories = calories;
        }
        public double Calories { get; private set; }
    }
}
