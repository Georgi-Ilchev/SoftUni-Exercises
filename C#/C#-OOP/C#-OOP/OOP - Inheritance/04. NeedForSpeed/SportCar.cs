using System;
using System.Collections.Generic;
using System.Text;

namespace _04._NeedForSpeed
{
     public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double DefaultFuelConsumption => 10;
    }
}
