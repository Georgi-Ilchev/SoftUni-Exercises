using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem6___parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car result = data.FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));

            if (result == null)
            {
                return false;
            }
            else
            {
                data.Remove(result);
                return true;
            }
        }
        public Car GetLatestCar()
        {
            if (Count == 0)
            {
                return null;

            }
            else
            {
                Car GetLatestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
                return GetLatestCar;
            }
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car result = data.FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));

            return result;
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {this.Type}:")
                .AppendLine($"{string.Join(Environment.NewLine, data)}");

            return result.ToString().TrimEnd();
        }
    }
}
