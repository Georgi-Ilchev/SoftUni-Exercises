using System;
using System.Collections.Generic;
using System.Text;

namespace _04._NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual double DefaultFuelConsumption => 1.25;
        public virtual double FuelConsumption { get; set; }

        // public const double DefaultFuelConsumption => 1.25;
        //public virtual double FuelConsumption
        //{
        //    get
        //    {
        //        return this.DefaultFuelConsumption;
        //    }
        //}

        public void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.DefaultFuelConsumption;
        }
        //public void Drive(double kilometers)
        //{
        //    this.Fuel -= kilometers * this.FuelConsumption;
        //}
    }
}
