using System;

namespace Nested_Conditional_Statements___exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool isBottom = (x1 <= x && x <= x2 && y == y2);
            bool isUp = (x1 <= x && x <= x2 && y == y1);
            bool isLeft = (y1 <= y && y <= y2 && x == x1);
            bool isRight = (y1 <= y && y <= y2 && x == x2);

            if (isBottom || isUp || isLeft || isRight)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
