using System;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int kgVegetables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double vegetables = priceVegetables * kgVegetables;
            double fruits = priceFruits * kgFruits;
            double all = (vegetables + fruits) / 1.94; 

            Console.WriteLine($"{all:f2}");
        }
    }
}
