using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> elements = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (!elements.ContainsKey(numbers))
                {
                    elements.Add(numbers, 0);
                }
                elements[numbers]++;
            }


            foreach (var item in elements.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine($"{item.Key}");
            }

            //foreach (var item in elements)
            //{
            //    if (item.Value % 2 == 0)
            //    {
            //        Console.WriteLine($"{item.Key}");
            //        break;
            //    }
            //}
        }
    }
}
