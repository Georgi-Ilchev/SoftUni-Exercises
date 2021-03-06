using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bottles = Console.ReadLine().Split().Select(int.Parse).ToList();

            Queue<int> cupsQueue = new Queue<int>(cups);
            Stack<int> bottlesStack = new Stack<int>(bottles);

            int wasted = 0;

            while (true)
            {
                int currentCup = cupsQueue.Peek();
                int currentBottle = bottlesStack.Peek();

                if (currentCup > currentBottle)
                {
                    while (currentCup > 0)
                    {
                        int cupValue = currentCup;

                        currentCup -= currentBottle;
                        currentBottle -= cupValue;

                        if (currentBottle <= 0)
                        {
                            bottlesStack.Pop();

                            if (currentCup > 0)
                            {
                                currentBottle = bottlesStack.Peek();
                            }
                        }
                    }

                    if (currentBottle > 0)
                    {
                        wasted += currentBottle;
                        bottlesStack.Pop();
                    }
                    cupsQueue.Dequeue();
                }
                else
                {
                    wasted += currentBottle - currentCup;
                    bottlesStack.Pop();
                    cupsQueue.Dequeue();
                }

                if (cupsQueue.Count <= 0)
                {
                    Console.WriteLine("Bottles: " + string.Join(" ", bottlesStack));
                    break;
                }
                if (bottlesStack.Count <= 0)
                {
                    Console.WriteLine("Cups: " + string.Join(" ", cupsQueue));
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
