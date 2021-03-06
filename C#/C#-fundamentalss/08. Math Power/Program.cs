using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculatePower(n, power));
        }
        static double CalculatePower(double number, double power)
        {
            double result = 1;
            //int secondResult = 0;
            
                for (int i = 0; i < power; i++)
                {
                    result *= number;
                }
                return result;
            
            //else
            //{
            //    return secondResult;
            //}
            
        }
    }
}
