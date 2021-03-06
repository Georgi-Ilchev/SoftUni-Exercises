using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] splitted = input.Split(" ");
                    string command = splitted[0];
                    string name = splitted[1];

                    if (command == "Enroll")
                    {
                        if (!heroes.ContainsKey(name))
                        {
                            heroes[name] = new List<string>();
                            //heroes.Add(name, new List<string>());
                        }
                        else
                        {
                            Console.WriteLine($"{name} is already enrolled.");
                        }
                    }
                    else if (command == "Learn")
                    {
                        string spellName = splitted[2];

                        if (heroes.ContainsKey(name))
                        {
                            if (!heroes[name].Contains(spellName))
                            {
                                heroes[name].Add(spellName);
                            }
                            else
                            {
                                Console.WriteLine($"{name} has already learnt {spellName}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{name} doesn't exist.");
                        }
                    }
                    else if (command == "Unlearn")
                    {
                        string spellName = splitted[2];

                        if (heroes.ContainsKey(name))
                        {
                            if (heroes[name].Contains(spellName))
                            {
                                heroes[name].Remove(spellName);
                            }
                            else
                            {
                                Console.WriteLine($"{name} doesn't know {spellName}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{name} doesn't exist.");
                        }
                    }
                }
            }
            Console.WriteLine("Heroes:");

            foreach (var item in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"== {item.Key}:");

                int count = 0;

                foreach (var kvp in item.Value)
                {
                    count++;
                    if (count==item.Value.Count)
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
        }
    }
}
