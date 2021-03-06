using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List < Vehicle > catalogue = new List<Vehicle>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                string type = command[0].ToLower();
                string model = command[1];
                string color = command[2].ToLower();
                int horsePower = int.Parse(command[3]);
                var currentVehicle = new Vehicle(type, model, color, horsePower);
                catalogue.Add(currentVehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();
                if (model == "Close the Catalogue")
                {
                    break;
                }
                Console.WriteLine(catalogue.Find(x=> x.Model == model));
            }

            var onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            var onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();
            double totalCarsPower = 0.0;
            double totalTrucksPower = 0.0;

            foreach (var car in onlyCars)
            {
                totalCarsPower += car.HorsePower;
            }

            foreach (var truck in onlyTrucks)
            {
                totalTrucksPower += truck.HorsePower;
            }

            double averageCarsHorsePower = totalCarsPower / onlyCars.Count;
            double averageTrucksHorsePower = totalTrucksPower / onlyTrucks.Count;

            if (onlyCars.Count >0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

    }
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public override string ToString()
        {
            string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" +
                                $"Horsepower: {this.HorsePower}";
            return vehicleStr;
        }



    }


}

