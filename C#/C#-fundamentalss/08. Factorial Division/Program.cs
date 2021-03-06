using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double sum = 0;
            double lastSum = Factorial(sum, num1, num2);

            Console.WriteLine($"{lastSum:f2}");
        }
        static double Factorial(double sum, int num1, int num2)
        {
            double firstSum = 1.0;
            double secondSum = 1.0;
            for (int i = num1; i > 0; i--)
            {
                firstSum *= i;
            }

            for (int j = num2; j > 0; j--)
            {
                secondSum *= j;
            }
            sum = (firstSum / secondSum);

            return sum;
        }
    }
}
