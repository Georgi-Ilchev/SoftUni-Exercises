using System;

namespace Conditional_Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            double travelPrice = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double earnedMoneybeforeDiss =
                puzzels * 2.60 + dolls * 3 + bears * 4.10 + minions * 8.20 + trucks * 2;

            int totalToysCount = puzzels + dolls + bears + minions + trucks;

            double moneyAfterfirsDiss = earnedMoneybeforeDiss; 

            if (totalToysCount >= 50)
            {
                moneyAfterfirsDiss = earnedMoneybeforeDiss * 0.75;
            }
            double moneyAfterRent = moneyAfterfirsDiss * 0.9;

            if (moneyAfterRent >= travelPrice)
            {
                Console.WriteLine($"Yes! {moneyAfterRent - travelPrice:f2} lv left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! {travelPrice - moneyAfterRent:f2} lv needed.");
            }
        }
    }
}
