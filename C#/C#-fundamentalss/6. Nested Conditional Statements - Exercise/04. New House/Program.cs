using System;

namespace _04._New_House
{
    class Program
    {
        private const int rose = 5;
        private const double dahh = 3.80;
        private const double tulips = 2.80;
        private const int narcissus = 3;
        private const double gladiolus = 2.50;    //246.4               88 * 2.80       15%  *0.85
        static void Main(string[] args)
        {

            string flower = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowersOfGladiolus = flowerCount * gladiolus;
            double flowersOfNarcissus = flowerCount * narcissus;
            double flowersOfTulips = flowerCount * tulips;
            double flowersOfDah = flowerCount * dahh;
            double flowersOfRose = flowerCount * rose;




            double allSum = 0;
            double sumLeft = 0;
            double all = 0.0;

            if (flower == "Roses")
            {
                if (flowerCount > 80)
                {
                    allSum = flowerCount * rose * 0.9;
                    all = Math.Abs(allSum);
                    sumLeft = budget - allSum;
                }
                else if (flowerCount <= 80)
                {
                    allSum = flowerCount * rose;
                    all = Math.Abs(allSum);
                    sumLeft = budget - allSum;
                }
            }
            else if (flower == "Dahlias")
            {
                if (flowerCount > 90)
                {
                    allSum = flowerCount * dahh * 0.85;
                    all = Math.Abs(allSum);
                    sumLeft = budget - allSum;
                }
                else if (flowerCount <= 90)
                {
                    allSum = flowerCount * dahh;
                    all = Math.Abs(allSum);
                    sumLeft = budget - allSum;
                }
            }
            else if (flower == "Tulips")
            {
                if (flowerCount > 80)
                {
                    allSum = flowerCount * tulips * 0.85;
                    sumLeft = budget - allSum;
                }
                else if (flowerCount <= 80)
                {
                    allSum = flowerCount * tulips;
                    sumLeft = budget - allSum;
                }
            }
            else if (flower == "Narcissus")
            {
                if (flowerCount < 120)                              // 119 broya
                {                                                   // 360 budget
                    allSum = (flowerCount * narcissus) * 0.15;        //3 leva
                    all = allSum + (flowerCount * narcissus);
                    sumLeft = budget - all;                    //0.15 oskupqwane * 0.85
                }                                                   //303.45
                else if (flowerCount >= 120)
                {
                    allSum = flowerCount * narcissus;
                    sumLeft = budget - allSum;
                }
            }
            else if (flower == "Gladiolus")
            {
                if (flowerCount < 80)
                {
                    allSum = (flowerCount * gladiolus) * 0.20;
                    all = flowersOfGladiolus + allSum;
                    sumLeft = budget - all;
                }
                else if (flowerCount >= 80)
                {
                    allSum = flowerCount * gladiolus;
                    all = Math.Abs(allSum);
                    sumLeft = budget - allSum;
                }


            }
            if (budget >= all)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flower} and {Math.Abs(sumLeft):f2} leva left.");

            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(sumLeft):F2} leva more.");
            }
        }
    }
}
