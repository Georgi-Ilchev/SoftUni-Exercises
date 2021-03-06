using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> elements = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (!elements.ContainsKey(currentSymbol))
                {
                    elements.Add(currentSymbol,0);
                }
                elements[currentSymbol]++;
            }

            foreach (var item in elements.OrderBy(y=>y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
