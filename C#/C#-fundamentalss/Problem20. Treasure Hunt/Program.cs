using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem20._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] command = input.Split(" ").ToArray();

                if (command[0] == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        bool isExist = false;
                        for (int j = 0; j < items.Count; j++)
                        {
                            if (command[i] == items[j])
                            {
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist == false)
                        {
                            items.Insert(0, command[i]);
                        }
                    }
                }
                else if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);
                    
                    if (index >= 0 && index < items.Count)
                    {
                        items.Add(items[index]);
                        items.RemoveAt(index);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Steal")
                {

                    int countOfStolenTreasure = int.Parse(command[1]);
                    if (countOfStolenTreasure < items.Count)
                    {
                        int firstIndex = items.Count - countOfStolenTreasure;
                        List<string> stolenItems = new List<string>();
                        for (int i = firstIndex; i < items.Count; i++)
                        {
                            stolenItems.Add(items[i]);
                        }
                        Console.WriteLine(string.Join(", ", stolenItems));
                        items.RemoveRange(firstIndex, countOfStolenTreasure);
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", items));
                        items.RemoveRange(0, items.Count);
                    }
                }
            }

            int countOfLetters = 0;
            foreach (string item in items)
            {
                countOfLetters += item.Length;
            }
            double trasureGained = (double)countOfLetters / items.Count;

            if (trasureGained > 0)
            {
                Console.WriteLine($"Average treasure gain: {trasureGained:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
