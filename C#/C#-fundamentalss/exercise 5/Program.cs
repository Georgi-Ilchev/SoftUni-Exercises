using System;

namespace exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int kids = 0;
            int adults = 0;
            double moneyKids = 0.0;
            double moneyAdults = 0.0;
            string command;
            
            while ((command = Console.ReadLine()) != "Christmas")
            {
                int years = int.Parse(command);
                if (years >=0 && years <=16)
                {
                    kids++;
                }
                else if (years>16)
                {
                    adults++;
                }
                
            }
            moneyKids = kids * 5;
            moneyAdults = adults * 15;

            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {moneyKids}");
            Console.WriteLine($"Money for sweaters: {moneyAdults}");
        }
    }
}
