using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Polymorphism
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public double Height { get; private set; }
        public double Width { get; private set; }


        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.Width + 2 * this.Height;
        }

        public override string Draw()
        {
            return $"{base.Draw()}{this.GetType().Name}";
        }
    }
}
