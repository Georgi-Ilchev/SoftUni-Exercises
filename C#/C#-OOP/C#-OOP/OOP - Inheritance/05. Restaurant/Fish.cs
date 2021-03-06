using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Restaurant
{
    public class Fish : MainDish
    {
        private const double FishGrams = 22;
        public Fish(string name, decimal price)
            :base(name,price,FishGrams)
        {

        }
    }
}
