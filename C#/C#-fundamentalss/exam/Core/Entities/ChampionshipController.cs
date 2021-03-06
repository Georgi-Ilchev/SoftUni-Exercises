using exam.Core.Contracts;
using exam.Models.Cars.Contracts;
using exam.Models.Cars.Entities;
using exam.Models.Drivers.Contracts;
using exam.Models.Drivers.Entities;
using exam.Models.Races.Contracts;
using exam.Models.Races.Entities;
using exam.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace exam.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            ICar car = this.cars.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IDriver driver = this.drivers.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException($"Driver {raceName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (this.cars.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            this.cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driver = new Driver(driverName);
            if (this.drivers.Models.Any(x => x.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            this.drivers.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            IRace newRace = new Race(name, laps);
            this.races.Add(newRace);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var participants = race.Drivers;

            if (participants.Count < 3)
            {
                throw new InvalidOperationException
                    ($"Race {raceName} cannot start with less than 3 participants.");
            }

            var sortedParicipants = participants
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {sortedParicipants[0].Name} wins {raceName} race.")
              .AppendLine($"Driver {sortedParicipants[1].Name} wins {raceName} race.")
              .AppendLine($"Driver {sortedParicipants[2].Name} wins {raceName} race.");

            return sb.ToString().TrimEnd();

            //"Driver {first driver name} wins {race name} race."
            //"Driver {second driver name} is second in {race name} race."
            //"Driver {third driver name} is third in {race name} race."
        }
    }
}
