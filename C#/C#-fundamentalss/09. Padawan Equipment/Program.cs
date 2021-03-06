using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabers = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            double sabersMore = Math.Abs (lightsabers * 0.1);
            double sabersPrice = (lightsabers + sabersMore) * students;
            double robesPrice = robes * students;
            double freeBelts = Math.Floor(students / 6.00);
            double freeBelts1 = freeBelts * belts;
            double beltsPrice = (belts * students) - freeBelts1;

            double allSum = sabersPrice + robesPrice + beltsPrice;
            if (money >= allSum)
            {
                Console.WriteLine($"The money is enough - it would cost {allSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {allSum - money:f2}lv more.");

            }
        }


    }
}
