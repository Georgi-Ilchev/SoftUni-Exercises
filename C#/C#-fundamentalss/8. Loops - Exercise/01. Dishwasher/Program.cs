using System;

namespace _01._Dishwasher
{

    class Program
    {
        public static object TryParse { get; private set; }

        static void Main(string[] args)
        {
            int countOfBottles = int.Parse(Console.ReadLine());


            int liquid = countOfBottles * 750;
            int cnt = 0;

            var nml = 0;
            int smallDishes = 0;
            int bigDishes = 0;
            var usedLiquid = 0;
            var newDishes = 0;

            string command = Console.ReadLine();
            while (command != "End")
            {
                newDishes = int.Parse(command);
                if (cnt == 2)
                {
                    var pots = newDishes * 15;
                    if (liquid >= pots)
                    {
                        liquid -= pots;
                        usedLiquid += pots;
                        bigDishes += newDishes;
                        cnt = 0;

                    }
                }
                else
                {
                    var dishes = newDishes * 5;
                    if (liquid >= dishes)
                    {
                        liquid -= dishes;
                        usedLiquid += dishes;
                        smallDishes += int.Parse(command);
                        cnt++;

                    }

                }

                if (nml > liquid)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (cnt == 2)
            {
                nml = newDishes * 15;
            }
            else
            {
                nml = newDishes * 5;
            }

            var allDishes = smallDishes + bigDishes;
            if (liquid >= usedLiquid)
            {
                Console.WriteLine($"Detergent was enough!");
                Console.WriteLine($"{smallDishes} dishes and {bigDishes} pots were washed.");
                Console.WriteLine($"Leftover detergent {liquid} ml.");
            }
            else
            {
                var neededLiquid = usedLiquid - liquid;
                var lastLiquid = nml - liquid;
                Console.WriteLine($"Not enough detergent, {lastLiquid} ml. more necessary!");
            }
        }
    }
}
