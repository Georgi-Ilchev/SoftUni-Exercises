using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._02.VehiclesExtension
{
    public class Validator
    {
        public static void CheckPositiveNumber(double value)
        {
            if (value < 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
        }
    }
}
