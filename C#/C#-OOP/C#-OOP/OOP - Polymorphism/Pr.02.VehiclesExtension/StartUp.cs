using System;
using System.Text;

namespace Pr._02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = (Car)Factory();
            Truck truck = (Truck)Factory();
            Bus bus = (Bus)Factory();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine().Trim();
                string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = splitted[0] + splitted[1];
                action = action.ToLower();
                double argument = double.Parse(splitted[2]);

                switch (action)
                {
                    case "drivecar":
                        car.Drive(argument);
                        break;
                    case "drivetruck":
                        truck.Drive(argument);
                        break;
                    case "drivebus":
                        bus.Drive(argument);
                        break;
                    case "driveemptybus":
                        bus.DriveWithoutPeople(argument);
                        break;
                    case "refuelcar":
                        car.Refuel(argument);
                        break;
                    case "refueltruck":
                        truck.Refuel(argument);
                        break;
                    case "refuelbus":
                        bus.Refuel(argument);
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
        private static Vehicle Factory()
        {
            string[] splitted = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string typeVehicle = splitted[0];
            double fuelQuantity = double.Parse(splitted[1]);
            double litersPerKm = double.Parse(splitted[2]);
            double tankCapacity = double.Parse(splitted[3]);

            switch (typeVehicle)
            {
                case "Car":
                    return new Car(fuelQuantity, litersPerKm, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, litersPerKm, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, litersPerKm, tankCapacity);
                default:
                    return null;
            }
        }
    }
}
