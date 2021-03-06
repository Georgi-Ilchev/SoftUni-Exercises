using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toysCounter = 0;
            int savedMoney = 0;
            int stolenLeva = 0;
            

            for (int currentYear = 1; currentYear <= age; currentYear++)
            {
                if (currentYear % 2 == 0)
                {
                    savedMoney += 10;
                    stolenLeva ++;
                }
                else
                {
                    toysCounter ++;
                }
            }
            Console.WriteLine($"saved money {savedMoney}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
