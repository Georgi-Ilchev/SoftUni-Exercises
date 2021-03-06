using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int minSymbols = 4;

        private string model;
        private int horsePower;
        //private double cubicCentimeters;

        protected Car(string model, int horsePower, double cubicCentimeres, int minHorsePower, int maxHorsePower)
        {
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeres;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < minSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, minSymbols));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public int MaxHorsePower { get; }
        public int MinHorsePower { get; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
