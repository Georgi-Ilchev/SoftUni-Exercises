﻿using System;

namespace Pr._02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * (base.FuelConsumption + ADDITIONAL_CONSUMPTION);
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double totalFuel = base.FuelQuantity + liters;
                if (totalFuel > base.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += liters;
                }
            }
        }
    }
}
