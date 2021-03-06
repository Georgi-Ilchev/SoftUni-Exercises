using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            Func<string, bool> tryParseFunc = TryParse();

            for (int i = 0; i < n; i++)
            {
                //{model} {power} {displacement} {efficiency};
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                //int displacement = int.Parse(input[2]);
                //string efficiency = input[3];


                Engine engine = CreateEngine(tryParseFunc, input, model, power);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];

                Engine engine = engines.Find(e => e.Model == engineModel);
                Car car = CreateCar(tryParseFunc, input, model, engine);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static Func<string, bool> TryParse()
        {
            return x =>
            {
                int number;
                if (Int32.TryParse(x, out number))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }

        private static Car CreateCar(Func<string, bool> tryParseFunc, string[] inputArgs, string model, Engine engine)
        {
            Func<string[], Car> createCar = x =>
            {
                if (x.Length == 4)
                {
                    var weight = int.Parse(inputArgs[2]);
                    var color = inputArgs[3];

                    return new Car(model, engine, weight, color);
                }
                else if (inputArgs.Length == 3)
                {

                    if (tryParseFunc(inputArgs[2]))
                    {
                        var weight = int.Parse(inputArgs[2]);
                        return new Car(model, engine, weight);
                    }
                    else
                    {
                        var color = inputArgs[2];
                        return new Car(model, engine, color);
                    }
                }
                else
                {
                    return new Car(model, engine);
                }


            };
            var currCar = createCar(inputArgs);
            return currCar;
        }

        private static Engine CreateEngine(Func<string, bool> tryParseFunc, string[] inputArgs, string model, int power)
        {
            Func<string[], Engine> createEngine = x =>
            {
                if (x.Length == 4)
                {
                    var displacement = int.Parse(x[2]);
                    var efficiency = x[3];

                    return new Engine(model, power, displacement, efficiency);
                }
                else if (x.Length == 3)
                {
                    if (tryParseFunc(x[2]))
                    {
                        return new Engine(model, power, int.Parse(x[2]));
                    }
                    else
                    {
                        return new Engine(model, power, x[2]);
                    }
                }
                else
                {
                    return new Engine(model, power);
                }

            };
            var currEngine = createEngine(inputArgs);
            return currEngine;
        }
    }
}
