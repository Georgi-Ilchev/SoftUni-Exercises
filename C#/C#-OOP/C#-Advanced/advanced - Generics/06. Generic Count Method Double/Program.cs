using System;
using System.Collections.Generic;

namespace _06._Generic_Count_Method_Double
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

            Box<double> box = new Box<double>(values);

            int counter = box.GetCountOfGreaterValues(value);
            Console.WriteLine(counter);
        }
    }
}
