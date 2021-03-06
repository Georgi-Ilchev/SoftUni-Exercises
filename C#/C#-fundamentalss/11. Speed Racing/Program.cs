using System;
using System.Collections.Generic;

namespace _11._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List <Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                cars.Add(new Car(Console.ReadLine().Split()));
            }
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                cars.Find(c => c.Model == command[1]).Drive(int.Parse(command[2]));
                command = Console.ReadLine().Split();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKm { get; set; }
        public int DistanceTraveled { get; set; }
        
        public Car(string[] carCharacterstics)
        {
            this.Model = carCharacterstics[0];
            this.FuelAmount = decimal.Parse(carCharacterstics[1]);
            this.FuelConsumptionPerKm = decimal.Parse(carCharacterstics[2]);
        }
        public void Drive (int distance)
        {
            decimal fuelNeeded = distance * this.FuelConsumptionPerKm;

            if (this.FuelAmount>=fuelNeeded)
            {
                this.DistanceTraveled += distance;
                this.FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
