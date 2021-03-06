using System;

namespace test5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumGuest = int.Parse(Console.ReadLine());
            string command;
            double result = 0.0;
            int countPeople = 0;

            while ((command = Console.ReadLine()) != "The restaurant is full")
            {
                int numberPeople = int.Parse(command);
                countPeople += numberPeople;

                if (numberPeople >= 5)
                {
                    result += numberPeople * 70;
                }
                else if (numberPeople < 5)
                {
                    result += numberPeople * 100;
                }
            }
            double sumLeft = sumGuest - result;
            if (sumGuest > result)
            {
                Console.WriteLine($"You have {countPeople} guests and {Math.Abs(result)} leva income, but no singer.");
            }
            else
            {
                Console.WriteLine($"You have {countPeople} guests and {Math.Abs(sumLeft)} leva left.");
            }
        }
    }
}
