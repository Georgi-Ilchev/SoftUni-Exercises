using System;

namespace _05.rectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateRectangeArea(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }
        static int CalculateRectangeArea(int a, int b)
        {
            return a * b;
        }
    }
}
