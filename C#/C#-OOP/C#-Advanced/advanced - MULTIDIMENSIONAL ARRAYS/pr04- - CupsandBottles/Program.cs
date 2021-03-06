using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace pr04____CupsandBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Stack<int> cups = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Pop();
                int currentBottle = bottles.Pop();

                if (currentBottle < currentCup)
                {
                    int current = currentCup - currentBottle;
                    cups.Push(current);
                }
                else
                {
                    wastedWater += currentBottle - currentCup;
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: " + (string.Join(" ", bottles)));
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: " + (string.Join(" ", cups)));
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");

            ///////////////////////////////////////////////////////////////////////////////////////////////
            
            //2
            Queue<int> cupSize = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottless = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int sumWastedWater = 0;
            int wastedWaterr = 0;
            while (cupSize.Count > 0 && bottless.Count > 0)
            {
                int aCup = cupSize.Peek();
                if (wastedWaterr < 0) aCup = wastedWaterr;
                wastedWaterr = bottless.Pop() - Math.Abs(aCup);
                if (wastedWaterr >= 0)
                {
                    sumWastedWater += wastedWaterr;
                    cupSize.Dequeue();
                    wastedWaterr = 0;
                }
            }
            if (bottless.Count > 0)
                Console.WriteLine($"Bottles: {string.Join(" ", bottless)}");
            if (cupSize.Count > 0)
                Console.WriteLine($"Cups: {string.Join(" ", cupSize)}");
            Console.WriteLine($"Wasted litters of water: {sumWastedWater}");
        }
    }
}
