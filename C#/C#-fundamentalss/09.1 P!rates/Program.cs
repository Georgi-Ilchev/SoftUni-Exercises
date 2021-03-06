using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._1_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> populations = new Dictionary<string, int>();
            Dictionary<string, int> golds = new Dictionary<string, int>();
            int count = 0;

            while (input != "Sail")
            {
                string[] tokens = input.Split("||");
                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (populations.ContainsKey(city) && golds.ContainsKey(city))
                {
                    populations[city] += population;
                    golds[city] += gold;
                }
                else
                {
                    populations.Add(city, population);
                    golds.Add(city, gold);
                    count++;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split("=>");
                string command = tokens[0];
                string town = tokens[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    populations[town] -= people;
                    golds[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (populations[town] <= 0 || golds[town] <= 0)
                    {
                        count--;
                        populations.Remove(town);
                        golds.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        golds[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {golds[town]} gold.");
                    }
                }
                input = Console.ReadLine();
            }

            golds = golds.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            if (count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {count} wealthy settlements to go to:");

                foreach (var item in golds)
                {
                    Console.WriteLine($"{item.Key} -> Population: {populations[item.Key]} citizens, Gold: {golds[item.Key]} kg");
                }
            }
        }
    }
}
