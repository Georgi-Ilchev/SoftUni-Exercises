using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plantsData = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("<->")
                    .ToArray();

                string plant = tokens[0];
                decimal rarity = decimal.Parse(tokens[1]);

                if (plantsData.ContainsKey(plant))
                {
                    plantsData[plant].Rarity = rarity;
                }

                else
                {
                    List<decimal> rating = new List<decimal>();

                    Plant newPlant = new Plant()
                    {
                        Rarity = rarity,
                        Rating = rating,
                        AverageRating = 0
                    };

                    plantsData.Add(plant, newPlant);
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Exhibition")
                {
                    break;
                }

                else if (command[0] == "Rate:")
                {
                    Rate(plantsData, command);
                }

                else if (command[0] == "Update:")
                {
                    Update(plantsData, command);
                }

                else if (command[0] == "Reset:")
                {
                    Reset(plantsData, command);
                }

                else
                {
                    Console.WriteLine("error");
                }
            }

            foreach (var item in plantsData)
            {
                if (item.Value.Rating.Count > 1)
                {
                    decimal average = item.Value.Rating.Sum();

                    average /= item.Value.Rating.Count;

                    item.Value.AverageRating = average;
                }

                else
                {
                    item.Value.AverageRating = item.Value.Rating.Sum();
                }
            }

            plantsData = plantsData.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.AverageRating).ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in plantsData)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.AverageRating:f2}");
            }
        }

        static void Rate(Dictionary<string, Plant> plantsData, string[] command)
        {
            string plant = command[1];
            decimal rating = decimal.Parse(command[3]);

            if (plantsData.ContainsKey(plant))
            {
                plantsData[plant].Rating.Add(rating);
            }

            else
            {
                Console.WriteLine("error");
            }
        }

        static void Update(Dictionary<string, Plant> plantsData, string[] command)
        {
            string plant = command[1];
            decimal newRarity = decimal.Parse(command[3]);

            if (plantsData.ContainsKey(plant))
            {
                plantsData[plant].Rarity = newRarity;
            }

            else
            {
                Console.WriteLine("error");
            }
        }

        static void Reset(Dictionary<string, Plant> plantsData, string[] command)
        {
            string plant = command[1];

            if (plantsData.ContainsKey(plant))
            {
                for (int i = 0; i < plantsData[plant].Rating.Count; i++)
                {
                    plantsData[plant].Rating.RemoveRange(0, plantsData[plant].Rating.Count);
                }
            }

            else
            {
                Console.WriteLine("error");
            }
        }
    }

    class Plant
    {
        public decimal Rarity { get; set; }
        public List<decimal> Rating { get; set; }
        public decimal AverageRating { get; set; }
    }
}

    

