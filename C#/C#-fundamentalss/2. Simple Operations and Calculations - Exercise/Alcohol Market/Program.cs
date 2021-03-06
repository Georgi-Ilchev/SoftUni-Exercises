using System;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskeyPrice = double.Parse(Console.ReadLine());
            double beerLittres = double.Parse(Console.ReadLine());
            double whineLittres = double.Parse(Console.ReadLine());
            double rakiaLittres = double.Parse(Console.ReadLine());
            double wiskeyLittres = double.Parse(Console.ReadLine());

            double rakiaPrice = wiskeyPrice / 2;
            double whinePrice = rakiaPrice - (0.4 * rakiaPrice);
            double beerPrice = rakiaPrice - (0.8 * rakiaPrice);

            double rakiaSum = rakiaLittres * rakiaPrice;
            double whineSum = whineLittres * whinePrice;
            double beerSum = beerLittres * beerPrice;
            double wiskeySum = wiskeyLittres * wiskeyPrice;

            double allSum = rakiaSum + whineSum + beerSum + wiskeySum;

            Console.WriteLine($"{allSum:f2}");


            
        }
    }
}
