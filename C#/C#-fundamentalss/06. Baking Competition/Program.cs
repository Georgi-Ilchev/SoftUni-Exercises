using System;

namespace _06._Baking_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int playersNumber = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            

            double cookiesPrice = 0.0;
            int cookiesCounter = 0;

            double cakesPrice = 0.0;
            int cakesCounter = 0;

            double wafflesPrice = 0.0;
            int wafflesCounter = 0;

            for (int i = 1; i <= playersNumber; i++)
            {
                string sweetType = Console.ReadLine();
                if (sweetType == "Stop baking!")
                {
                    Console.WriteLine($"{name} baked {cookiesCounter} cookies, {cakesCounter} cakes and {wafflesCounter} waffles.");
                    name = Console.ReadLine();
                    sweetType = Console.ReadLine();
                    sweetCount = int.Parse(Console.ReadLine());
                    continue;
                }
                int sweetCount = int.Parse(Console.ReadLine());
                if (sweetType == "cookies")
                {
                    cookiesPrice = sweetCount * 1.50;
                    cookiesCounter += sweetCount;

                }
                else if (sweetType == "cakes")
                {
                    cakesPrice = sweetCount * 7.80;
                    cakesCounter += sweetCount;

                }
                else if (sweetType == "waffles")
                {
                    wafflesPrice = sweetCount * 2.30;
                    wafflesCounter += sweetCount;

                }

                
                if (sweetType == "Stop baking!")
                {
                    Console.WriteLine($"{name} baked {cookiesCounter} cookies, {cakesCounter} cakes and {wafflesCounter} waffles.");
                    name = Console.ReadLine();
                    continue;
                }
                
                

            }

            double allSum = cookiesCounter + cakesCounter + wafflesCounter;
            double donateSum = cookiesPrice + cakesPrice + wafflesPrice;
            Console.WriteLine($"All bakery sold: {allSum}");
            Console.WriteLine($"Total sum for charity: {donateSum}");
        }
    }
}
