using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._2_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> citys = new Dictionary<string, City>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sail")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("||");
                    string city = tokens[0];
                    int population = int.Parse(tokens[1]);
                    int gold = int.Parse(tokens[2]);

                    if (!citys.ContainsKey(city))
                    {
                        City newCity = new City()
                        {
                            Gold = gold,
                            Population = population
                        };
                        citys.Add(city, newCity);
                    }
                    else
                    {
                        citys[city].Population += population;
                        citys[city].Gold += gold;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("=>");
                    string command = tokens[0];
                    string town = tokens[1];

                    if (command == "Plunder")
                    {
                        int people = int.Parse(tokens[2]);
                        int gold = int.Parse(tokens[3]);

                        citys[town].Population -= people;
                        citys[town].Gold -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (citys[town].Population <= 0 || citys[town].Gold <= 0)
                        {
                            citys.Remove(town);
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
                            citys[town].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {citys[town].Gold} gold.");
                        }

                    }
                }
            }
            citys = citys.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            if (citys.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {citys.Count} wealthy settlements to go to:");

                foreach (var city in citys)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
        }
        class City
        {
            public int Population { get; set; }
            public int Gold { get; set; }
        }
    }
}
