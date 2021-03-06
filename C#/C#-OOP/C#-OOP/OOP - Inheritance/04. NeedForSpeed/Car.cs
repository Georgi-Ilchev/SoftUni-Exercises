using System;
using System.Collections.Generic;
using System.Text;

namespace _04._NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base (horsePower, fuel)
        {

        }
        public override double DefaultFuelConsumption => 3;
    }
}
