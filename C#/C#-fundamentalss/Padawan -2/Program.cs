using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //double money = double.Parse(Console.ReadLine());
            //int students = int.Parse(Console.ReadLine());
            //double lightsabers = double.Parse(Console.ReadLine());
            //double robes = double.Parse(Console.ReadLine());
            //double belts = double.Parse(Console.ReadLine());

            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalLightsaber = (countOfStudents + Math.Ceiling(countOfStudents * 0.10)) * priceOfLightsaber;
            double totalRobes = countOfStudents * priceOfRobes;

            double totalBelts = 0;

            if (countOfStudents >= 10)
            {
                totalBelts = (countOfStudents - countOfStudents / 6) * priceOfBelts;
            }
            else
            {
                totalBelts = countOfStudents * priceOfBelts;
            }

            double totalPrice = totalBelts + totalRobes + totalLightsaber;

            if (amountOfMoney - totalPrice >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                double neededMoney = totalPrice - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }


        }
    }
}