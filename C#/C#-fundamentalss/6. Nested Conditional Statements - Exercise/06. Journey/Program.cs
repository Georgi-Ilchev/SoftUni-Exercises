using System;

namespace _06._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            int percentages = 0;
            string destination = "";
            string type = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    
                    percentages = 30;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    percentages = 70;
                    type = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    percentages = 40;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    percentages = 80;
                    type = "Hotel";
                }
                destination = "Balkans";
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                percentages = 90;
                type = "Hotel";
            }
            

            double totalSum = budget * percentages / 100;
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {totalSum:f2}");
        }
        
    }
}
