using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._1_Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split("|");
                string brand = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                Car car = new Car() { Mileage = mileage, Fuel = fuel };
                cars.Add(brand, car);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] command = input.Split(" : ");
                string car = command[1];

                if (command[0] == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuel = int.Parse(command[3]);

                    if (cars[car].Fuel - fuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Fuel -= fuel;
                        cars[car].Mileage += distance;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (cars[car].Mileage >= 100000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (command[0] == "Refuel")
                {
                    int fuel = int.Parse(command[2]);

                    if (cars[car].Fuel + fuel > 75)
                    {
                        fuel = 75 - cars[car].Fuel;
                    }
                    cars[car].Fuel += fuel;
                    Console.WriteLine($"{car} refueled with {fuel} liters");

                }
                else if (command[0] == "Revert")
                {
                    int kilometers = int.Parse(command[2]);

                    cars[car].Mileage -= kilometers;

                    if (cars[car].Mileage < 10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
