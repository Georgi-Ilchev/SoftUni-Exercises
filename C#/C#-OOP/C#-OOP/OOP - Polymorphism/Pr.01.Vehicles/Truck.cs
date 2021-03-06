namespace Pr._01.Vehicles
{
    public class Truck : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 1.6;
        private static readonly double QTY_MODIFIER = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + ADDITIONAL_CONSUMPTION)
        {
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * QTY_MODIFIER;
        }
    }
}
