using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPumps = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < numOfPumps; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }
            int totalFuel = 0;

            for (int i = 0; i < numOfPumps; i++)
            {
                string currentInfo = circle.Dequeue();
                var info = currentInfo.Split(" ").Select(int.Parse).ToArray();

                var fuel = info[0];
                var distance = info[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                circle.Enqueue(currentInfo);
            }

            var firstElement = circle.Dequeue().Split().ToArray();
            Console.WriteLine(firstElement[2]);
        }
    }
}
