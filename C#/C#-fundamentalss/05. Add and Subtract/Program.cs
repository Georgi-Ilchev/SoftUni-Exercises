using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            
            SumOfFirstAndSecond(first, second);
            Console.WriteLine(Subtract(first, second, third));
        }
        static int SumOfFirstAndSecond(int first, int second)
        {
            int sum = 0;
            sum = first + second;
            return sum;
        }
        static int Subtract (int first, int second, int third)
        {
            int sum = SumOfFirstAndSecond(first, second);
            int lastSum = 0;
            lastSum = sum - third;
            return lastSum;
        }
    }
}
