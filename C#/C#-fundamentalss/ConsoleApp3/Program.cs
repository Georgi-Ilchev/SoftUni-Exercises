using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> raritys = new Dictionary<string, int>();
            Dictionary<string, int> ratings = new Dictionary<string, int>();
            Dictionary<string, List<int>> ratingsCount = new Dictionary<string, List<int>>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("<->");
                string plant = tokens[0];
                int rarity = int.Parse(tokens[1]);

                if (raritys.ContainsKey(plant))
                {
                    raritys[plant] = rarity;
                }
                else
                {
                    raritys.Add(plant, rarity);
                    ratings.Add(plant, 0);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Exhibition")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];


                    if (command == "Rate")
                    {
                        string plantOrrating = tokens[1];
                        string[] newSplit = plantOrrating.Split(" - ");
                        string plant = newSplit[0];
                        int rating = int.Parse(newSplit[1]);

                        ratings[plant] += rating;
                        ratingsCount[plant].Add(rating);
                    }
                    else if (command == "Update")
                    {
                        string plantOrrating = tokens[1];
                        string[] newSplit = plantOrrating.Split(" - ");
                        string plant = newSplit[0];
                        int rarity = int.Parse(newSplit[1]);

                        raritys[plant] = rarity;
                    }
                    else if (command == "Reset")
                    {
                        string plant = tokens[1];
                        //raritys.Remove(plant);
                        ratings[plant] = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
            //Console.WriteLine("Plants for the exhibition:");
            ////plants = plants.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.)
            //ratings = ratings.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //foreach (var kvp in ratings)
            //{
            //    double average = raritys[kvp.Key];
            //    Console.WriteLine($"- {kvp.Key}; Rarity:{average}; Rating: {kvp.Value:f2} lt.");
            //}
            Console.WriteLine("Plants for the exhibition:");
            raritys = raritys.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in raritys)
            {
                double average = ratings[kvp.Key] / ratingsCount.Count;
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value}; Rating: {average:f2} lt.");
            }
        }
    }
}
