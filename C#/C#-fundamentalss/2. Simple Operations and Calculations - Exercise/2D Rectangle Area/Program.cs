using System;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double lenght = Math.Abs(x1 - x2);
            double width = Math.Abs(y1 - y2);
            double area = lenght * width;
            double per = 2 * (lenght + width);

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{per:f2}");

        }
    }
}
