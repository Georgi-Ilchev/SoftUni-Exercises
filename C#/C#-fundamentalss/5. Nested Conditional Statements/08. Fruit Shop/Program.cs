using System;

namespace _08._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quality = double.Parse(Console.ReadLine());

            if (day == "Monday" ||
                day == "Tuesday" ||
                day == "Wednesday" ||
                day == "Thursday" ||
                day == "Friday")
            {
                if (fruit == "banana")
                {
                    Console.WriteLine($"{quality * 2.50:f2}");
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine($"{quality * 1.20:f2}");
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine($"{quality * 0.85:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine($"{quality * 1.45:f2}");
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine($"{quality * 2.70:f2}");
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine($"{quality * 5.50:f2}");
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine($"{quality * 3.85:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }

            }




            else if (day == "Saturday" ||
                 day == "Sunday")
            {
                if (fruit == "banana")
                {
                    Console.WriteLine($"{quality * 2.70:f2}");
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine($"{quality * 1.25:f2}");
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine($"{quality * 0.90:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine($"{quality * 1.60:f2}");
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine($"{quality * 3.00:f2}");
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine($"{quality * 5.60:f2}");
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine($"{quality * 4.20:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }


            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
