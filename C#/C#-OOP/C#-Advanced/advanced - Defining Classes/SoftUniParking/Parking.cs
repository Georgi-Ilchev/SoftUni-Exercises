using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            bool exist = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);

            if (exist)
            {
                return $"Car with that registration number, already exists!";
            }

            if (capacity == cars.Count)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }
        public string RemoveCar(string registratonNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == registratonNumber);

            if (car == null)
            {
                return $"Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);

            return $"Successfully removed {registratonNumber}";
        }

        public Car GetCar(string registrationNumber)
            => cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                var car = cars.FirstOrDefault(x => x.RegistrationNumber == regNumber);
                cars.Remove(car);
            }
        }
    }
}
