using System;

namespace _05._1_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double coinsInput = double.Parse(Console.ReadLine());
            double coins = coinsInput * 100;
            double coinsCount = 0;

            while (coins >= 1)
            {
                coinsCount++;
                if (coins >= 200)
                {
                    double num = Math.Floor(coins / 100);
                    double twoCoinsCount = Math.Floor(num / 2);
                    coinsCount += twoCoinsCount;
                    double rem = num % 2;
                    coinsCount--;
                    coins %= 100;
                    coins += rem * 100;

                }
                else if (coins >= 100)
                {
                    coins -= 100;
                }
                else if (coins >= 50)
                {
                    coins -= 50;
                }
                else if (coins >= 20)
                {
                    coins -= 20;
                }
                else if (coins >= 10)
                {
                    coins -= 10;
                }
                else if (coins >= 5)
                {
                    coins -= 5;
                }
                else if (coins >= 2)
                {
                    coins -= 2;
                }
                else if (coins >= 1)
                {
                    coins -= 1;
                }
            }
            Console.WriteLine(coinsCount);
        }
    }
}
