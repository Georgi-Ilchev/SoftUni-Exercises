using System;

namespace _07._Flower_Shop
{
    class Program
    {
        private const double magnoliaP = 3.25;
        private const double hyacinthP = 4.00;
        private const double roseP = 3.50;
        private const double cactusP = 8;
        static void Main(string[] args)
        {
            int magnolia = int.Parse(Console.ReadLine());
            int hyacinth = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double sum = 0.0;
            double finalSum = 0.0;
            double sumLeft = 0.0;

            sum = magnolia * magnoliaP + hyacinth * hyacinthP + rose * roseP + cactus * cactusP;
            finalSum = sum * 0.95;
            sumLeft = Math.Ceiling(presentPrice - finalSum);
            var lastSum = Math.Abs(sumLeft);

            if (presentPrice <=finalSum)
            {
                Console.WriteLine($"She is left with {lastSum} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {lastSum} leva.");
            }

            

        }
    }
}
