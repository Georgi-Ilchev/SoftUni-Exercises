using System;
using System.Text;

namespace Pr._01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = (Car)Factory();
            Truck truck = (Truck)Factory();
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

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
                        sb.AppendLine(car.Drive(argument));
                        break;
                    case "drivetruck":
                        sb.AppendLine(truck.Drive(argument));
                        break;
                    case "refuelcar":
                        car.Refuel(argument);
                        break;
                    case "refueltruck":
                        truck.Refuel(argument);
                        break;
                }
            }
            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
        private static Vehicle Factory()
        {
            string[] splitted = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string typeVehicle = splitted[0];
            double fuelQuantity = double.Parse(splitted[1]);
            double litersPerKm = double.Parse(splitted[2]);

            switch (typeVehicle)
            {
                case "Car":
                    return new Car(fuelQuantity, litersPerKm);
                case "Truck":
                    return new Truck(fuelQuantity, litersPerKm);
                default:
                    return null;
            }
        }
    }
}
