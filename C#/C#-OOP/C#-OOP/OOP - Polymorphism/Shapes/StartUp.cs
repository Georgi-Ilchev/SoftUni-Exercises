using OOP___Polymorphism;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double height = -1;
                double widht = 7;
                Shape rectangle = new Rectangle(height, widht);
                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(rectangle.CalculatePerimeter());
                Console.WriteLine(rectangle.Draw());

                double radius = 5;
                Shape circle = new Circle(radius);
                Console.WriteLine(circle.CalculateArea());
                Console.WriteLine(circle.CalculatePerimeter());
                Console.WriteLine(circle.Draw());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
