using System;

namespace _10._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedBack = Console.ReadLine();

            int nights = days - 1;
            double sumForNights = 0;

            if (roomType == "room for one person")
            {
                sumForNights = 18 * nights;
            }
            else if (roomType == "apartment")
            {
                if (nights < 10)
                {
                    sumForNights = (25 * nights) * 0.7; //30% ot cenata
                }
                else if (nights >= 10 && nights <= 15)
                {
                    sumForNights = (25 * nights) * 0.65; //35% ot cenata
                }
                else if (nights > 15)
                {
                    sumForNights = (25 * nights) * 0.5; //50% ot cenata
                }
            }
            else if (roomType == "president apartment")
            {
                if (nights < 10)
                {
                    sumForNights = (35 * nights) * 0.9;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    sumForNights = (35 * nights) * 0.85;
                }
                else if (nights > 15)
                {
                    sumForNights = (35 * nights) * 0.8;
                }

            }
            if (feedBack == "positive")
            {
                sumForNights = sumForNights * 1.25;
            }
            else if (feedBack == "negative")
            {
                sumForNights = sumForNights * 0.9;
            }



            Console.WriteLine($"{sumForNights:f2}");
        }


    }
}
