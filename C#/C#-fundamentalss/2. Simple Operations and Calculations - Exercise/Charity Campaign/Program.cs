using System;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter days:");
            int days = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter people:");
            int people = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter cakes:");
            int cakes = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter waffles:");
            int waffles = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter pancakes:");
            int pancakes = int.Parse(Console.ReadLine());

            double cakesPrice = cakes * 45;
            double wafflesPrice = waffles * 5.80;
            double pancakesPrice = pancakes * 3.20;

            double totalPricefor1 = (cakesPrice + wafflesPrice + pancakesPrice) * people;
            double totalPrice = totalPricefor1 * days;

            double diff = totalPrice / 8;
            double result = totalPrice - diff;


            Console.WriteLine($"The result is: {result:f2}");



        }
    }
}
