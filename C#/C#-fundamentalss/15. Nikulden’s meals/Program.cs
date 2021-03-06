using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            int unLiked = 0;
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("-");
                    string command = tokens[0];
                    string guest = tokens[1];
                    string meal = tokens[2];

                    if (command == "Like")
                    {
                        if (!guests.ContainsKey(guest))
                        {
                            guests[guest] = new List<string>();
                        }
                        if (guests[guest].Contains(meal))
                        {
                            continue;
                        }
                        else
                        {
                            guests[guest].Add(meal);
                        }
                    }
                    else if (command == "Unlike")
                    {
                        if (!guests.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                            continue;
                        }
                        if (!guests[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guests[guest].Remove(meal);
                            unLiked++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                    }
                }
            }
            foreach (var item in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"{item.Key}:");

                int count = 0;

                foreach (var kvp in item.Value)
                {
                    count++;
                    if (count == item.Value.Count)
                    {
                        Console.Write($" {kvp}");
                    }
                    else
                    {
                        Console.Write($" {kvp},");
                    }
                }
                Console.WriteLine();

            }
            Console.WriteLine($"Unliked meals: {unLiked}");
        }
    }
}
