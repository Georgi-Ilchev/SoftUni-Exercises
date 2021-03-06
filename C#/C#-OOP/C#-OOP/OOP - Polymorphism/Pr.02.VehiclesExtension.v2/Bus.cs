﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._02.VehiclesExtension.v2
{
    public class Bus : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * (base.FuelConsumption + ADDITIONAL_CONSUMPTION);
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }
        public void DriveEmpty(double distance)
        {
            double neededFuel = distance * base.FuelConsumption;
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
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
