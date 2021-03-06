using System;
using System.Collections.Generic;
using System.Linq;

namespace _24._Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> peoples = new Dictionary<string, List<int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Results")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(":");
                    string command = tokens[0];

                    if (command == "Add")
                    {
                        string name = tokens[1];
                        int health = int.Parse(tokens[2]);
                        int energy = int.Parse(tokens[3]);

                        if (!peoples.ContainsKey(name))
                        {
                            peoples.Add(name, new List<int>());
                            peoples[name].Add(health);
                            peoples[name].Add(energy);
                        }
                        else
                        {
                            peoples[name][0] += health;
                        }
                    }
                    else if (command == "Attack")
                    {
                        string attackerName = tokens[1];
                        string defenderName = tokens[2];
                        int damage = int.Parse(tokens[3]);

                        if (peoples.ContainsKey(attackerName) && peoples.ContainsKey(defenderName))
                        {
                            peoples[defenderName][0] -= damage;
                            peoples[attackerName][1] -= 1;

                            if (peoples[defenderName][0] <= 0)
                            {
                                peoples.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }

                            if (peoples[attackerName][1] == 0)
                            {
                                peoples.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }
                    }
                    else if (command == "Delete")
                    {
                        string username = tokens[1];

                        if (peoples.ContainsKey(username))
                        {
                            peoples.Remove(username);
                        }

                        if (username == "All")
                        {
                            peoples = new Dictionary<string, List<int>>();
                        }
                    }
                }
            }

            Console.WriteLine($"People count: {peoples.Count}");

            //peoples = peoples.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var name in peoples.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))// тук сортираме
            {
                Console.WriteLine($"{name.Key} - {name.Value[0]} - {name.Value[1]}"); // принтираме
            }
        }
    }
}
