using System;
using System.Collections.Generic;
using System.Linq;

namespace _31._Practice_sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Road> roads = new Dictionary<string, Road>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("->");
                    string command = tokens[0];

                    if (command == "Add")
                    {
                        string road = tokens[1];
                        string racer = tokens[2];

                        if (!roads.ContainsKey(road))
                        {
                            List<string> racers = new List<string>();

                            Road newRoad = new Road()
                            {
                                Racer = racers
                            };
                            roads.Add(road, newRoad);
                            roads[road].Racer.Add(racer);
                        }
                        else
                        {
                            roads[road].Racer.Add(racer);
                        }
                    }
                    else if (command == "Move")
                    {
                        string currentRoad = tokens[1];
                        string racer = tokens[2];
                        string nextRoad = tokens[3];

                        if (roads[currentRoad].Racer.Contains(racer))
                        {
                            roads[currentRoad].Racer.Remove(racer);
                            roads[nextRoad].Racer.Add(racer);
                        }
                    }
                    else if (command == "Close")
                    {
                        string road = tokens[1];

                        if (roads.ContainsKey(road))
                        {
                            roads.Remove(road);
                        }
                    }
                }
            }
            Console.WriteLine("Practice sessions:");

            roads = roads.OrderByDescending(x => x.Value.Racer.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var road in roads)
            {
                Console.WriteLine($"{road.Key}");

                foreach (var item in road.Value.Racer)
                {
                    Console.WriteLine($"++{item}");
                }
            }
        }
        class Road
        {
            public List<string> Racer { get; set; }
        }
    }
    
}
