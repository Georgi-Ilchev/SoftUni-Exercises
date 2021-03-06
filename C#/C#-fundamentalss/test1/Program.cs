using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyFood = double.Parse(Console.ReadLine());
            double moneySouv = double.Parse(Console.ReadLine());
            double moneyHotel = double.Parse(Console.ReadLine());

            double travel = 420;
            double gasoline = travel / 100 * 7;
            double moneyGasoline = gasoline * 1.85;

            double moneySpend = 3 * moneyFood + 3 * moneySouv;

            double firstdayHotel = moneyHotel * 0.9;
            double seconddayHotel = moneyHotel * 0.85;
            double thirdayHotel = moneyHotel * 0.8;

            double allSum = moneyGasoline + moneySpend + firstdayHotel + seconddayHotel + thirdayHotel;


            Console.WriteLine($"Money needed: {allSum:f2}");
        }
    }
}
