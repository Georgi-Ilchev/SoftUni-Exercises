using System;

namespace _04._Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string dayOrnight = Console.ReadLine();

            double taxi = 0.0;
            double autobus = 0.0;
            double train = 0.0;

            if (dayOrnight == "day")
            {
                if (km < 20)
                {
                    taxi = 0.70 + (km * 0.79);
                    Console.WriteLine($"{taxi:f2}");
                }
                else if (km >= 20 && km <=99)
                {
                    autobus = km * 0.09;
                    Console.WriteLine($"{autobus:f2}");
                }
                else if (km >= 100)
                {
                    train = km * 0.06;
                    Console.WriteLine($"{train:f2}");
                }

            }
            else if (dayOrnight == "night")
            {
                if (km < 20)
                {
                    taxi = 0.70 + (km * 0.90);
                    Console.WriteLine($"{taxi:f2}");
                }
                else if (km >= 20 && km <=99)
                {
                    autobus = km * 0.09;
                    Console.WriteLine($"{autobus:f2}");
                }
                else if (km >= 100)
                {
                    train = km * 0.06;
                    Console.WriteLine($"{train:f2}");
                }

            }
            

            
        }
    }
}
