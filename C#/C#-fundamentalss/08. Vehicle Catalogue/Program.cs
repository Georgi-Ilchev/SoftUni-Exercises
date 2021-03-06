using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();
                string[] command = input.Split("/");

                if (input == "end")
                {
                    break;
                }

                Car car = new Car();
                Truck truck = new Truck();

                string type = command[0];
                if (type == "Car")
                {
                    string brand = command[1];
                    string model = command[2];
                    string horsePower = command[3];

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;
                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    string brand = command[1];
                    string model = command[2];
                    string weight = command[3];

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;
                    trucks.Add(truck);
                }
            }
            List<Car> sortedCars = cars.OrderBy(c => c.Brand).ToList();
            List<Truck> sortedTrucks = trucks.OrderBy(c => c.Brand).ToList();

            Console.WriteLine("Cars:");
            foreach (Car car in sortedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (Truck truck in sortedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class CatalogVehicle
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

}
