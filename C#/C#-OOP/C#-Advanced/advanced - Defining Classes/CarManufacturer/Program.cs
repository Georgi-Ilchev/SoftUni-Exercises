using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Car lambo = new Car("lambo", "aventador", 2018);


            //Car car = new Car();

            //car.Make = "Alfa Romeo";
            //car.Model = "156jtd";
            //car.Year = 2002;

            //Engine engine = new Engine(150, 2400);
            //Tire[] tires = new Tire[]
            //{
            //    new Tire(2008,2000),
            //    new Tire(2018,1900),
            //    new Tire(2098,2100),
            //};
            //Car toyota = new Car("Toyota", "Avensis", 2019, 70, 8, engine, tires);

            //car.FuelConsumption = 12;
            //car.FuelQuantity = 200;
            //car.Drive(20);
            //car.Drive(10);

            //Console.WriteLine(car.WhoAmI());


            //----------------------------------------------------------------------------------------------------------------------------
            List<Tire[]> tires = new List<Tire[]>();
            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var currTires = new Tire[4]
                {
                    new Tire(int.Parse(splitted[0]), double.Parse(splitted[1])),
                    new Tire(int.Parse(splitted[2]), double.Parse(splitted[3])),
                    new Tire(int.Parse(splitted[4]), double.Parse(splitted[5])),
                    new Tire(int.Parse(splitted[6]), double.Parse(splitted[7]))
                };

                tires.Add(currTires);

                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(splitted[0]);
                double cubicCapacity = double.Parse(splitted[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                command = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = splitted[0];
                string model = splitted[1];
                int year = int.Parse(splitted[2]);
                double fuelQuantity = double.Parse(splitted[3]);
                double fuelCapacity = double.Parse(splitted[4]);
                int engineIndex = int.Parse(splitted[5]);
                int tireIndex = int.Parse(splitted[6]);

                if ((engineIndex >= 0 && engineIndex < engines.Count) && (tireIndex >= 0 && tireIndex < tires.Count))
                {
                    Car car = new Car(make, model, year, fuelQuantity, fuelCapacity, engines[engineIndex], tires[tireIndex]);
                    cars.Add(car);
                }

                command = Console.ReadLine();
            }

            cars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            //if (cars.Any())
            //{
            //    foreach (var car in cars)
            //    {
            //        car.Drive(20);
            //        Console.WriteLine(car.WhoAmI());
            //    }
            //}
            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    StringBuilder builder = new StringBuilder();

                    car.Drive(20);

                    builder.AppendLine($"Make: {car.Make}");
                    builder.AppendLine($"Model: {car.Model}");
                    builder.AppendLine($"Year: {car.Year.ToString()}");
                    builder.AppendLine($"HorsePowers: {car.Engine.HorsePower.ToString()}");
                    builder.AppendLine($"FuelQuantity: {car.FuelQuantity.ToString()}");

                    Console.Write(builder);
                }
            }
        }
    }
}
