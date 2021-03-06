using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var plants = new Dictionary<string, double>();
            var plantsRating = new Dictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var tokens = line.Split("<->");
                var name = tokens[0];
                var rarity = double.Parse(tokens[1]);
                if (plants.ContainsKey(name))
                {
                    plants[name] = rarity;
                }
                else
                {
                    plants.Add(name, rarity);
                    plantsRating.Add(name, new List<double>());
                }

            }
            var input = Console.ReadLine();
            while (input != "Exhibition")
            {
                var separator = new string[2] { ": ", " - " };
                var command = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var action = command[0];
                switch (action)
                {
                    case "Rate":
                        var name = command[1];
                        var rating = double.Parse(command[2]);
                        if (plantsRating.ContainsKey(name))
                        {

                            plantsRating[name].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                    case "Update":
                        name = command[1];
                        var rarity = double.Parse(command[2]);
                        if (plants.ContainsKey(name))
                        {

                            plants[name] = rarity;
                        }
                        else
                        {

                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        name = command[1];
                        if (plantsRating.ContainsKey(name))
                        {

                            plantsRating[name].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                input = Console.ReadLine();

            }
            var averageRating = new Dictionary<string, List<double>>();
            foreach (var item in plantsRating)
            {
                if (item.Value.Count == 0)
                {
                    averageRating.Add(item.Key, new List<double> { 0 });
                }
                else
                {
                    averageRating.Add(item.Key, new List<double> { item.Value.Average() }); //plant + avg.Rating
                }
            }
            var totalPlants = new Dictionary<string, List<double>>();
            foreach (var element in plants)
            {
                averageRating[element.Key].Add(element.Value);
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in averageRating.OrderByDescending(x => x.Value[1]).ThenByDescending(x => x.Value[0]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[1]}; Rating: {plant.Value[0]:f2}");
            }
        }
    }
}
