using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                //string[] input = Console.ReadLine().Split(new char[] { '-', '>', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] inputArgs = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = inputArgs[0];

                string[] clothes = inputArgs[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }

                //for (int j = 0; j < clothes.Length; j++)
                //{
                //    if (!wardrobe[color].ContainsKey(clothes[j]))
                //    {
                //        wardrobe[color].Add(clothes[j], 0);
                //    }
                //    wardrobe[color][clothes[j]]++;
                //}
            }

            string[] search = Console.ReadLine().Split();
            string searchedColor = search[0];
            string searchedDress = search[1];

            foreach (var item in wardrobe)
            {
                string color = item.Key;
                Dictionary<string, int> clothes = item.Value;

                Console.WriteLine($"{color} clothes:");

                foreach (var cqp in clothes)
                {
                    string cloth = cqp.Key;
                    int qnt = cqp.Value;

                    if (color == searchedColor && cloth == searchedDress)
                    {
                        Console.WriteLine($"* {cloth} - {qnt} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {qnt}");
                    }
                }
            }

            //foreach (var item in wardrobe)
            //{
            //    Console.WriteLine($"{item.Key} clothes:");

            //    foreach (var clothing in item.Value)
            //    {
            //        Console.WriteLine($"* {clothing.Key} - {clothing.Value} ");
            //        if (clothing.Key == searchedDress && item.Key == searchedColor)
            //        {
            //            Console.Write("(found!)");
            //        }
            //        Console.WriteLine();
                    
            //    }
            //}
        }
    }
}
