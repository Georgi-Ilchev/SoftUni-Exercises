using System;

namespace _06._Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int foodKg = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtleFood = double.Parse(Console.ReadLine());

            double dogNeed = daysCount * dogFood;
            double catNeed = daysCount * catFood;
            double turtleNeed = Math.Abs(daysCount * turtleFood)/1000;
            double allFood = dogNeed + catNeed + turtleNeed;
            double kgLeft = Math.Floor(foodKg - allFood);

            if (foodKg >= allFood)
            {
                Console.WriteLine($"{kgLeft} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{kgLeft*-1} more kilos of food are needed.");
            }
        }
    }       
}
