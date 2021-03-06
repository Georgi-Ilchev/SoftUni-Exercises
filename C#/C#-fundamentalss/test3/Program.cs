using System;
using System.Linq;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {


                
            string typeSushi = Console.ReadLine();
            string nameRestourant = Console.ReadLine();
            int portion = int.Parse(Console.ReadLine());
            char yesOrNo =char.Parse(Console.ReadLine());

            double allSum = 0.0;
            double delivery = 0.0;
            double lastSum = 0.0;

            if (nameRestourant == "Sushi Zone")
            {
                switch (typeSushi)
                {
                    case "sashimi": allSum = portion * 4.99; break;
                    case "maki": allSum = portion * 5.29; break;
                    case "uramaki": allSum = portion * 5.99; break;
                    case "temaki": allSum = portion * 4.29; break;
                }
            }
            else if (nameRestourant == "Sushi Time")
            {
                switch (typeSushi)
                {
                    case "sashimi": allSum = portion * 5.49; break;
                    case "maki": allSum = portion * 4.69; break;
                    case "uramaki": allSum = portion * 4.49; break;
                    case "temaki": allSum = portion * 5.19; break;
                }
            }
            else if (nameRestourant == "Sushi Bar")
            {
                switch (typeSushi)
                {
                    case "sashimi": allSum = portion * 5.25; break;
                    case "maki": allSum = portion * 5.55; break;
                    case "uramaki": allSum = portion * 6.25; break;
                    case "temaki": allSum = portion * 4.75; break;
                }
            }
            else if (nameRestourant == "Asian Pub")
            {
                switch (typeSushi)
                {
                    case "sashimi": allSum = portion * 4.50; break;
                    case "maki": allSum = portion * 4.80; break;
                    case "uramaki": allSum = portion * 5.50; break;
                    case "temaki": allSum = portion * 5.50; break;
                }
            }
            else
            {
                Console.WriteLine($"{nameRestourant} is invalid restaurant!");
                return;
            }

            if (yesOrNo == 'Y')
            {
                delivery = allSum * 0.2;
                lastSum = delivery + allSum;
                Console.WriteLine($"Total price: {Math.Ceiling(lastSum)} lv.");
            }
            else if (yesOrNo == 'N')
            {
                Console.WriteLine($"Total price: {Math.Ceiling(allSum)} lv.");
            }

            


        }
    }
}
