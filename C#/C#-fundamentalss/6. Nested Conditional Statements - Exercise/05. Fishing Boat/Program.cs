using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetGroup = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            int fisherCount = int.Parse(Console.ReadLine());

            double ship = 0.0;
            double sumLeft = 0.0;

            


            if (season == "spring")
            {
                if (fisherCount > 0 && fisherCount <= 6)
                {
                    ship = 3000.0 * 0.9;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount > 7 && fisherCount <= 11)
                {
                    ship = 3000 * 0.85;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount >= 12)
                {
                    ship = 3000 * 0.75;
                    sumLeft = budgetGroup - ship;
                }


            }
            else if (season == "summer" || season == "autumn")
            {
                if (fisherCount <= 6 && fisherCount > 0)
                {
                    ship = 4200 * 0.90;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount >= 7 && fisherCount <= 11)
                {
                    ship = 4200 * 0.85;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount >= 12)
                {
                    ship = 4200 * 0.75;
                    sumLeft = budgetGroup - ship;
                }

            }
                                                                              
            else if (season == "winter")
            {
                if (fisherCount > 0 && fisherCount <= 6)
                {
                    ship = 2600 * 0.9;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount >= 7 && fisherCount <= 11)
                {
                    ship = 2600 * 0.85;
                    sumLeft = budgetGroup - ship;
                }
                else if (fisherCount > 12)
                {
                    ship = 2600 * 0.75;
                    sumLeft = budgetGroup - ship;
                }

            }

            if (fisherCount % 2 == 0 && season != "autumn")
            {
                sumLeft  *= 0.95;
            }


            if (budgetGroup >= ship)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(sumLeft):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(sumLeft):f2} leva.");
            }
        }
    }
}
