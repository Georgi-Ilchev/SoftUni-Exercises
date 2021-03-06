using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Tire[] tires;
        private Engine engine;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get { return make; }

            set { make = value; }
        }
        public string Model
        {
            get { return model; }

            set { model = value; }
        }
        public int Year
        {
            get { return year; }

            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }

            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }

            set { fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            var remainingFuel = FuelQuantity - ((distance * FuelConsumption) / 100);

            if (remainingFuel >= 0)
            {
                FuelQuantity = remainingFuel;
            }

            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity:F1}");
            return sb.ToString();
        }
        //public Car()
        //{
        //    Make = "VW";
        //    Model = "Golf";
        //    Year = 2025;
        //    FuelQuantity = 200;
        //    FuelConsumption = 10;
        //}

        //public Car(string make, string model, int year) : this()
        //{
        //    Make = make;
        //    Model = model;
        //    Year = year;
        //}

        //public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        //{
        //    FuelConsumption = fuelConsumption;
        //    FuelQuantity = fuelQuantity;
        //}

        //public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine,Tire[]tires) : this(make, model, year,fuelQuantity, fuelConsumption)
        //{
        //    Engine = engine;
        //    Tires = tires;
        //}

        //public string Make { get; set; }
        //public string Model { get; set; }
        //public int Year { get; set; }
        //public double FuelQuantity { get; set; }
        //public double FuelConsumption { get; set; }
        //public Engine Engine { get; set; }
        //public Tire[] Tires { get; set; }

        //public void Drive(double distance)
        //{
        //    double consumption = distance * this.FuelConsumption;
        //    if (this.FuelQuantity - consumption <= 0)
        //    {
        //        Console.WriteLine($"Not enough fuel to perform this trip!");
        //    }
        //    else
        //    {
        //        this.FuelQuantity -= consumption;
        //    }
        //}

        //public string WhoAmI()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Make: { this.Make}");
        //    sb.AppendLine($"Model: { this.Model}");
        //    sb.AppendLine($"Year: { this.Year}");
        //    sb.Append($"Fuel: { this.FuelQuantity:F2}L");
        //    return sb.ToString();
        //}
    }
}
