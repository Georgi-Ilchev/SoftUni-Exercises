using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mileage = new Dictionary<string, int>();
            Dictionary<string, int> fuels = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] cars = input.Split("|");
                string car = cars[0];
                int mile = int.Parse(cars[1]);
                int fuelL = int.Parse(cars[2]);
                mileage.Add(car, mile);
                fuels.Add(car, fuelL);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(" : ");
                    string command = tokens[0];
                    string carName = tokens[1];
                    if (command == "Drive")
                    {
                        int distance = int.Parse(tokens[2]);
                        int fuel = int.Parse(tokens[3]);

                        if (fuels[carName] < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            mileage[carName] += distance;
                            fuels[carName] -= fuel;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (mileage[carName] >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {carName}!");
                                fuels.Remove(carName);
                                mileage.Remove(carName);
                            }
                        }
                    }
                    else if (command == "Refuel")
                    {
                        int fuel = int.Parse(tokens[2]);
                        if (fuels[carName] + fuel > 75)
                        {
                            fuel = 75 - fuels[carName];
                        }
                        fuels[carName] += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                    else if (command == "Revert")
                    {
                        int kilometers = int.Parse(tokens[2]);

                        if (mileage[carName] - kilometers > 10000)
                        {
                            mileage[carName] -= kilometers;
                            Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                        }
                        else
                        {
                            mileage[carName] = 10000;
                        }
                    }
                }
            }
            mileage = mileage.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in mileage)
            {
                int fuel = fuels[kvp.Key];
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
