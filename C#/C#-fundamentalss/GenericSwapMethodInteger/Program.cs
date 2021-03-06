using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> values = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int currentValue = int.Parse(Console.ReadLine());
                values.Add(currentValue);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapMe<int> box = new SwapMe<int>(values);

            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
