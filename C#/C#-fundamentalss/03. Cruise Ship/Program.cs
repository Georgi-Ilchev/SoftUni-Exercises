using System;

namespace _03._Cruise_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            string cruisType = Console.ReadLine();
            string cabinType = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double finalSum = 0;

            if (cruisType == "Mediterranean")
            {
                switch (cabinType)
                {
                    case "standar cabin": finalSum = 27.50 * 4 * nights; break;
                    case "cabin with balcony": finalSum = 30.20 * 4 * nights; break;
                    case "apartment": finalSum = 40.50 * 4 * nights; break;
                }
            }
            else if (cruisType == "Adriatic")
            {
                switch (cabinType)
                {
                    case "standard cabin": finalSum = 22.99 * 4 * nights; break;
                    case "cabin with balcony": finalSum = 25.00 * 4 * nights; break;
                    case "apartment": finalSum = 34.99 * 4 * nights; break;
                }
            }
            else if (cruisType == "Aegean")
            {
                switch (cabinType)
                {
                    case "standard cabin": finalSum = 23.00 * 4 * nights; break;
                    case "cabin with balcony": finalSum = 26.60 * 4 * nights; break;
                    case "apartment": finalSum = 39.80 * 4 * nights; break;
                }
            }


            if (nights > 7)
            {
                Console.WriteLine($"Annie's holiday in the {cruisType} sea costs {finalSum * 0.75:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Annie's holiday in the {cruisType} sea costs {finalSum:f2} lv.");
            }



        }
    }
}
