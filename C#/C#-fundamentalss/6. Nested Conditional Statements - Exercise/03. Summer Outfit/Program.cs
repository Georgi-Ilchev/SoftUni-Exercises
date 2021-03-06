using System;

namespace _03._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outFit = "";
            string shoes = "";

            if (degrees >= 10 && degrees <= 18)
            {
                if (time == "Morning")
                {
                    outFit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (time == "Afternoon")
                {
                    outFit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (time == "Evening")
                {
                    outFit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            else if (degrees > 18 && degrees <= 24)
            {
                if (time == "Morning")
                {
                    outFit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (time == "Afternoon")
                {
                    outFit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (time == "Evening")
                {
                    outFit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            else if (degrees >= 25)
            {
                if (time == "Morning")
                {
                    outFit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (time == "Afternoon")
                {
                    outFit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (time == "Evening")
                {
                    outFit = "Shirt";
                    shoes = "Moccasins";
                }
                
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outFit} and {shoes}.");
            
        }
        
    }
}
