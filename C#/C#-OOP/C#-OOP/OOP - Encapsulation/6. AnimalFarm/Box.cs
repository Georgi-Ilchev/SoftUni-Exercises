using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        //1.constants
        private const string INVALID_SIDE_EXC_MSG = "{0} cannot be zero or negative.";

        //2.private fields
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                //this.ValidateSide(value, nameof(Length));

                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                //this.ValidateSide(value, nameof(Width));

                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                //this.ValidateSide(value, nameof(Height));

                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double Volume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }

        public double SurfaceArea()
        {
            double area = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return area;
        }

        public double LateralSurfaceArea() => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                //throw new ArgumentException($"{paramName} cannot be zero or negative.");
                throw new ArgumentException(String.Format(INVALID_SIDE_EXC_MSG, paramName));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
