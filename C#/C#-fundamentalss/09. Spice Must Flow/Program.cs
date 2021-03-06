using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int allSum = 0;
            int counterDay = 0;

            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    counterDay++;
                    allSum += startingYield;
                    startingYield -= 10;
                }
                allSum -= (counterDay + 1) * 26;
                Console.WriteLine(counterDay);
                Console.WriteLine(allSum);
            }
            else
            {
                Console.WriteLine(counterDay);
                Console.WriteLine(allSum);
            }


        }
    }
}
