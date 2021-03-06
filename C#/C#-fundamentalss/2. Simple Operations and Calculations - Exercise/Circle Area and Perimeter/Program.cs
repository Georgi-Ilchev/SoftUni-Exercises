using System;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double S = Math.PI * r * r;
            double perimet = 2 * Math.PI * r;

            Console.WriteLine($"{S:f2}");
            Console.WriteLine($"{perimet:f2}");
        }
    }
}
