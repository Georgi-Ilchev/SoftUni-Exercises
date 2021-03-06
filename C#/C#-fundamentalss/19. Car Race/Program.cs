using System;
using System.Collections.Generic;
using System.Linq;

namespace _19._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> firstCarTime = new List<int>();
            List<int> secondCarTime = new List<int>();

            double firstSum = 0.0;
            double secondSum = 0.0;

            for (int i = 0; i < times.Count / 2; i++)
            {
                firstCarTime.Add(times[i]);
            }

            for (int i = times.Count - 1; i >= times.Count / 2 + 1; i--)
            {
                secondCarTime.Add(times[i]);
            }

            for (int i = 0; i < firstCarTime.Count; i++)
            {
                int currentSum = firstCarTime[i];
                firstSum += currentSum;

                if (currentSum == 0)
                {
                    double reduceTime = firstSum * 0.2;
                    firstSum -= reduceTime;
                }
            }

            for (int i = secondCarTime.Count - 1; i >= 0; i--)
            {
                int currentSum = secondCarTime[i];
                secondSum += currentSum;

                if (currentSum == 0)
                {
                    double reduceTime = secondSum * 0.2;
                    secondSum -= reduceTime;
                }
            }

            if (firstSum < secondSum)
            {
                Console.WriteLine($"The winner is left with total time: {firstSum}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondSum}");
            }

        }
    }
}
