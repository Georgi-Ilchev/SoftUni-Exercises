using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Number();
        }

        static void Number() //(int n)
        {
            int n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
            else if (n == 0)
            {
                Console.WriteLine($"The number {n} is zero.");
            }
            else
            {
                Console.WriteLine($"The number {n} is negative.");
            }
        }
    }
}
