using System;

namespace _08._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightCount = int.Parse(Console.ReadLine());

            double studio = 0.0;
            double apartment = 0.0;
            if (month == "May" || month == "October")
            {
                if (nightCount <= 7)
                {
                    studio = 50 * nightCount;
                    apartment = 65 * nightCount;
                }
                else if (nightCount >= 8 && nightCount <=14)
                {
                    studio = 50 * nightCount * 0.95;
                    apartment = 65 * nightCount;
                }
                else if (nightCount >= 15)
                {
                    studio = 50 * nightCount * 0.7;
                    apartment = 65 * nightCount;
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nightCount <=14)
                {
                    studio = 75.20 * nightCount;
                    apartment = 68.70 * nightCount;
                }
                else if (nightCount >=15)
                {
                    studio = 75.20 * nightCount * 0.8;
                    apartment = 68.70 * nightCount;
                }
                
            }
            else if (month == "July" || month == "August")
            {
                studio = 76 * nightCount;
                apartment = 77 * nightCount;
            }


            if (nightCount >=15)
            {
                apartment = apartment * 0.9;
            }

            Console.WriteLine($"Apartment: {apartment:f2} lv.");
            Console.WriteLine($"Studio: {studio:f2} lv.");
        }
    }
}
