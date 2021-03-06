using System;

namespace _02._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double priceForTicket = 0;

            //if (ticketType == "Premiere")
            //{
            //    priceForTicket = 12;
            //}
            //else if (ticketType == "Normal")
            //{
            //    priceForTicket = 7.50;
            //}
            //else if (ticketType =="Discount")
            //{
            //    priceForTicket = 5;
            //}

            switch (ticketType )
            {
                case "Premiere":
                    priceForTicket = 12; break;
                case "Normal":
                    priceForTicket = 7.5; break;
                case "Discount":
                    priceForTicket = 5; break;
            }

            int peopleCount = rows * cols;
            double totalPrice = peopleCount * priceForTicket;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
