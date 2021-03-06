using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double r = double.Parse(Console.ReadLine());
                double result = r * r;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double result = a * b;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double result = Math.PI * r * r;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double result = (a * b) / 2;
                Console.WriteLine($"{result:f3}");
            }
        }
    }
}
