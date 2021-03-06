using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string model = inputInfo[0];
                double fuelAmount = double.Parse(inputInfo[1]);
                double fuelConsumption = double.Parse(inputInfo[2]);

                Car car = new Car(model,fuelAmount,fuelConsumption);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] splitted = input.Split();
                string model = splitted[1];
                int amountOfKm = int.Parse(splitted[2]);

                //Car car = GetCar(cars,model);
                Car car = cars.FirstOrDefault(x => x.Model == model);
                car.Drive(amountOfKm);

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

        private static Car GetCar(List<Car>cars,string model)
        {
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }
    }
}
