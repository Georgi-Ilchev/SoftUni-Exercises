using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sortedDictionary = new SortedDictionary<int, int>();

            foreach (var item in numbers)
            {
                if (sortedDictionary.ContainsKey(item))
                {
                    sortedDictionary[item]++;
                }
                else
                {
                    sortedDictionary.Add(item, 1);
                }
            }

            foreach (var pair in sortedDictionary)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
