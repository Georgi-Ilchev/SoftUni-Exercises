    using System;

namespace Pr._02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 1.6;
        private static readonly double QTY_MODIFIER = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * (base.FuelConsumption + ADDITIONAL_CONSUMPTION);
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
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
                double totalFuel = base.FuelQuantity + (liters * QTY_MODIFIER);
                if (totalFuel > base.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += (liters * QTY_MODIFIER);
                }
            }
        }
    }
}
