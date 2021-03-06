using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> values = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double currentValue = double.Parse(Console.ReadLine());
                values.Add(currentValue);
            }

            double value = double.Parse(Console.ReadLine());

            Counter<double> box = new Counter<double>(values);

            int counter = box.GetCountOfGreaterValues(value);
            Console.WriteLine(counter);
        }
    }
}
