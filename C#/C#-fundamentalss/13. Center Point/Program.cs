using System;

namespace _13._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine("(" + String.Join(" ",CloseToZero(x1,y1,x2,y2) + ")"));
        }
        static string CloseToZero(double x1, double y1, double x2, double y2)
        {
            string closest = string.Empty;
            double firstPoint = Math.Abs(x1) + Math.Abs(y1);
            double secondPoint = Math.Abs(x2) + Math.Abs(y2);

            if (firstPoint < secondPoint)
            {
                closest += x1 + ", " + y1;
            }
            else if (firstPoint > secondPoint)
            {
                closest += x2 + ", " + y2;
            }
            else
            {
                closest += x1 + ", " + y1;
            }
            
            return closest;
        }
    }
}
