using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> values = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();
                values.Add(currentValue);
            }

            string value = Console.ReadLine();

            Counter<string> box = new Counter<string>(values);

            int counter = box.GetCountOfGreaterValues(value);
            Console.WriteLine(counter);
        }
    }
}
