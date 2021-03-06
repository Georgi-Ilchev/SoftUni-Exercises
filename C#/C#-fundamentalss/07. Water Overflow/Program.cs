using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            short totalLiters = 0;

            for (int i = 0; i < n; i++)
            {
                short liters = short.Parse(Console.ReadLine());

                if (totalLiters + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalLiters += liters;
                }
            }
            Console.WriteLine(totalLiters);

        }
    }
}
