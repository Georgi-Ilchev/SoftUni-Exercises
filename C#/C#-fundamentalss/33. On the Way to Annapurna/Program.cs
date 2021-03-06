using System;
using System.Collections.Generic;
using System.Linq;

namespace _33._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split("->").ToArray();
                string command = tokens[0];
                string storeName = tokens[1];

                if (command.Contains("Remove"))
                {
                    if (dict.ContainsKey(storeName))
                    {
                        dict.Remove(storeName);
                    }
                }

                if (command.Contains("Add"))
                {
                    var items = tokens[2].Split(",").ToList();

                    if (!dict.ContainsKey(storeName))
                    {
                        dict.Add(storeName, new List<string>());
                    }

                    for (int i = 0; i < items.Count; i++)
                    {
                        dict[storeName].Add(items[i]);
                    }
                }
            }

            Console.WriteLine("Stores list:");

            foreach (var (storeName, items) in dict.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{storeName}");

                foreach (var item in items)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
