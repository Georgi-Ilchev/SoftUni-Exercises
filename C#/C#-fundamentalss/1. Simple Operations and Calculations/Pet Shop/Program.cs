using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNumber = int.Parse(Console.ReadLine());
            int otherAnimalnumber = int.Parse(Console.ReadLine());
            double dogFoodprice = dogsNumber * 2.50;
            double otherAnimalsfoodPrice = otherAnimalnumber * 4;
            double allPrice = dogFoodprice + otherAnimalsfoodPrice;

            Console.WriteLine($"{allPrice:F2} lv.");
        }
    }
}
