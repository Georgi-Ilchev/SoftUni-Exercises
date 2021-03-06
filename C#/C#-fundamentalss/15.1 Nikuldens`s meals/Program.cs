using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._1_Nikuldens_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Guest> guests = new Dictionary<string, Guest>();
            int unLiked = 0;

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
                            List<string> meals = new List<string>();

                            Guest newGuest = new Guest()
                            {
                                Meals = meals
                            };
                            guests.Add(guest, newGuest);
                        }
                        if (guests[guest].Meals.Contains(meal))
                        {
                            continue;
                        }
                        else
                        {
                            guests[guest].Meals.Add(meal);
                        }
                    }
                    else if (command == "Unlike")
                    {
                        if (!guests.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                            continue;
                        }
                        if (!guests[guest].Meals.Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guests[guest].Meals.Remove(meal);
                            unLiked++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                    }
                }
            }
            guests = guests.OrderByDescending(x => x.Value.Meals.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var guest in guests)
            {
                Console.Write($"{guest.Key}:");
                int count = 0;

                foreach (var kvp in guest.Value.Meals)
                {
                    count++;
                    if (count == guest.Value.Meals.Count)
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
        class Guest
        {
            public List<string> Meals { get; set; }
        }
    }
}
