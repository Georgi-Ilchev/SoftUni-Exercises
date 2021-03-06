using System;

namespace p05
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            int countOfFishermans = int.Parse(Console.ReadLine());


            double priceOfBoatInSpring = 3000.0;
            double priceOfBoatInSummer = 4200.0;
            double priceOfBoatInWinter = 2600.0;
            double discount = 0.0;
            double priceIn = 0.0;
            double priceOfBoat = 0.0;

            if (season == "spring")
            {
                if (countOfFishermans > 0 && countOfFishermans <= 6)
                {
                    priceOfBoat = priceOfBoatInSpring;
                    discount = priceOfBoatInSpring * 0.10;
                    priceOfBoat -= discount;
                    
                }
                else if (countOfFishermans >= 7 && countOfFishermans <= 11)
                {

                    priceOfBoat = priceOfBoatInSpring;
                    discount = priceOfBoatInSpring * 0.15;
                    priceOfBoat -= discount;
                    priceIn = priceOfBoat - budget;
                }
                else if (countOfFishermans >= 12)
                {

                    priceOfBoat = priceOfBoatInSpring;
                    discount = priceOfBoatInSpring * 0.25;
                    priceOfBoat -= discount;
                   
                }
            }
            else if (season == "summer" || season == "autumn")
            {
                if (countOfFishermans > 0 && countOfFishermans <= 6)
                {
                    priceOfBoat = priceOfBoatInSummer;
                    discount = priceOfBoatInSummer * 0.10;
                    priceOfBoat -= discount;
                   
                }
                else if (countOfFishermans >= 7 && countOfFishermans <= 11)
                {

                    priceOfBoat = priceOfBoatInSummer;
                    discount = priceOfBoatInSummer * 0.15;
                    priceOfBoat -= discount;
                }
                else if (countOfFishermans >= 12)
                {

                    priceOfBoat = priceOfBoatInSummer;
                    discount = priceOfBoatInSummer * 0.75;
                    priceOfBoat -= discount;
                   
                }
            }
            else if (season == "winter")
            {
                if (countOfFishermans > 0 && countOfFishermans <= 6)
                {
                    priceOfBoat = priceOfBoatInWinter;
                    discount = priceOfBoatInWinter * 0.10;
                    priceOfBoat -= discount;
                    
                }
                else if (countOfFishermans >= 7 && countOfFishermans <= 11)
                {
                    priceOfBoat = priceOfBoatInWinter;
                    discount = priceOfBoatInWinter * 0.15;
                    priceOfBoat -= discount;
                    
                }
                else if (countOfFishermans >= 12)
                {
                    priceOfBoat = priceOfBoatInWinter;
                    discount = priceOfBoatInWinter * 0.25;
                    priceOfBoat -= discount;
                   
                }
            }


            if (countOfFishermans % 2 == 0 && season != "autumn")
            {
                var discount2 = 0.0;
                discount2 = priceOfBoat * 0.05;
                priceOfBoat -= discount2;
                priceIn = priceOfBoat - budget;

            }
            else
            {
                 priceIn = priceOfBoat - budget;
            }

           
            var moneysLeft = Math.Abs(priceIn);

            if (budget >= priceOfBoat)
            {
                Console.WriteLine($"Yes! You have {moneysLeft:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneysLeft:F2} leva.");
            }
        }
    }
}
