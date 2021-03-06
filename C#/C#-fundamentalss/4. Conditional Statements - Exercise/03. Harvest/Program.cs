using System;

namespace _03._Harvest
{
    class Program
    {
        //private const double harvest = 0.40;
        //private const double grapesneedforWine = 2.5;
        static void Main(string[] args)
        {
            int wineYard = int.Parse(Console.ReadLine()); //kv m loze
            double grapes = double.Parse(Console.ReadLine()); //grozde da 1 kv.m
            int liters = int.Parse(Console.ReadLine()); //nujni litra vino
            int workers = int.Parse(Console.ReadLine());

            
            double harvest = (wineYard * 0.4) * grapes;
            double wine = harvest / 2.5;
            double litersLeft = Math.Abs(wine - liters);
            double litersPerPerson = litersLeft / workers;


            if (wine < liters)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(litersLeft)} liters wine needed.");
            }
            else if (wine >= liters)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{(int)Math.Ceiling(litersLeft)} liters left -> {(int)Math.Ceiling(litersPerPerson)} liters per person.");

            }
        }
    }
}
