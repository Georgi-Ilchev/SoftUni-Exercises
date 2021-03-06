using System;

namespace Problem_10._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeed = double.Parse(Console.ReadLine());
            byte months = byte.Parse(Console.ReadLine());

            byte currentMonth = 0;
            double moneyColect = 0.0;
            double moneySpent = 0.0;
            double lastSum = 0.0;

            for (int i = 1; i <= months; i++)
            {
                currentMonth++;
                if (currentMonth %2 == 1 && currentMonth != 1)
                {
                    moneySpent = moneyColect * 0.16;
                    moneyColect -= moneySpent;
                }
                if (currentMonth %4==0)
                {
                    moneyColect += moneyColect * 0.25;
                }

                moneyColect += moneyNeed * 0.25;
                
            }
            if (moneyColect >= moneyNeed)
            {
                lastSum = moneyColect - moneyNeed;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {lastSum:f2}lv. for souvenirs.");
            }
            else
            {
                lastSum = moneyNeed - moneyColect;
                Console.WriteLine($"Sorry. You need {lastSum:f2}lv. more.");
            }
        }
    }
}
