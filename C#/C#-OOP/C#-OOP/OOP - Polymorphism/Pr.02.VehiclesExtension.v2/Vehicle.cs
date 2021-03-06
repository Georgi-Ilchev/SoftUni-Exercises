namespace Pr._02.VehiclesExtension.v2
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                Validator.CheckPositiveNumber(value);
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }
        public double TankCapacity
        {
            get => this.tankCapacity;
            set
            {
                Validator.CheckPositiveNumber(value);
                this.tankCapacity = value;
            }
        }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
