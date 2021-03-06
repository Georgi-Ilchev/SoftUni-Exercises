using System;

namespace exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();


            double price = 0.0;
            double priceH = 0.0;
            double totalPrice = 0.0;


            if (month == "march" || month == "april" || month == "may")
            {
                if (dayOrNight == "day")
                {
                    if (peopleCount >= 4)
                    {
                        price = 10.50 - (10.50 * 0.1);
                    }
                    else if (peopleCount < 4)
                    {
                        price = 10.50;
                    }

                    if (hours >= 5)
                    {
                        priceH = price - (price * 0.5);
                    }
                    else if (hours < 5)
                    {
                        priceH = price;
                    }
                }
                else if (dayOrNight == "night")
                {
                    if (peopleCount >= 4)
                    {
                        price = 8.4 - (8.4 * 0.1);
                    }
                    else if (peopleCount < 4)
                    {
                        price = 8.4;
                    }

                    if (hours >= 5)
                    {
                        priceH = price - (price * 0.5);
                    }
                    else if (hours < 5)
                    {
                        priceH = price;
                    }
                }
                
            }





            else if (month == "june" || month == "july" || month == "august")
            {
                if (dayOrNight == "day")
                {
                    if (peopleCount >= 4)
                    {
                        price = 12.60 - (12.60 * 0.1);
                    }
                    else if (peopleCount < 4)
                    {
                        price = 12.60;
                    }

                    if (hours >= 5)
                    {
                        priceH = price - (price * 0.5);
                    }
                    else if (hours < 5)
                    {
                        priceH = price;
                    }
                }
                else if (dayOrNight == "night")
                {
                    if (peopleCount >= 4)
                    {
                        price = 10.20 - (10.20 * 0.1);
                    }
                    else if (peopleCount < 4)
                    {
                        price = 10.20;
                    }

                    if (hours >= 5)
                    {
                        priceH = price - (price * 0.5);
                    }
                    else if (hours < 5)
                    {
                        priceH = price;
                    }
                }
            }
            totalPrice = peopleCount * priceH * hours;
            Console.WriteLine($"Price per person for one hour: {priceH:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");




        }
    }
}
