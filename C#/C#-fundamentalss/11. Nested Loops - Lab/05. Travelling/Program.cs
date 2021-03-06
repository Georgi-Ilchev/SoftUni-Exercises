using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double saveMoney = 0;
                double budget = double.Parse(Console.ReadLine());

                while (saveMoney<budget)
                {
                    double moneyIn = double.Parse(Console.ReadLine());
                    saveMoney += moneyIn;
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();

            }
        }
    }
}
