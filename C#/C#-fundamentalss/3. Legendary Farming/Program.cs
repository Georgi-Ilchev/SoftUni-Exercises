using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            bool isReached = false;
            while (!isReached)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string name = input[i + 1].ToLower();

                    if (materials.ContainsKey(name))
                    {
                        materials[name] += quantity;
                        if (materials[name] >= 250)
                        {
                            isReached = true;
                            string legendaryItem = FindTheLegendaryItem(name);
                            Console.WriteLine($"{legendaryItem} obtained!");
                            materials[name] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(name))
                        {
                            junk[name] = 0;
                        }
                        junk[name] += quantity;
                    }
                }
            }

            materials = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(a => a.Key.ToLower(), b => b.Value);
            junk = junk.OrderBy(x => x.Key.ToLower()).ToDictionary(a => a.Key.ToLower(), b => b.Value);

            foreach (var item in materials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        private static string FindTheLegendaryItem(string name)
        {
            string legendaryItem = string.Empty;
            switch (name)
            {
                case "shards":
                    legendaryItem = "Shadowmourne";
                    break;

                case "fragments":
                    legendaryItem = "Valanyr";
                    break;
                case "motes":
                    legendaryItem = "Dragonwrath";
                    break;
            }

            return legendaryItem;
        }
    }
}
