using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            for (int num1 = 2; num1 <= first; num1 += 2)
            {
                for (int num2 = 2; num2 <= second && num2 <= 7; num2 ++)
                {
                    if (num2 == 4 || num2 == 6)
                    {
                        continue;
                    }
                    for (int num3 = 2; num3 <= third; num3 += 2)
                    {
                        Console.WriteLine($"{num1} {num2} {num3}");

                    }
                }
            }
        }
    }
}
