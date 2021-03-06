using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._1_Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split();
                    string command = tokens[0];
                    string name = tokens[1];

                    if (command == "Enroll")
                    {
                        if (heroes.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} is already enrolled.");
                        }
                        else
                        {
                            List<string> spellBook = new List<string>();
                            Hero newHero = new Hero()
                            {
                                SpellBooks = spellBook
                            };
                            heroes.Add(name, newHero);
                        }
                    }
                    else if (command == "Learn")
                    {
                        string spell = tokens[2];

                        if (!heroes.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} doesn't exist.");
                        }
                        else
                        {
                            if (heroes[name].SpellBooks.Contains(spell))
                            {
                                Console.WriteLine($"{name} has already learnt {spell}.");
                            }
                            else
                            {
                                heroes[name].SpellBooks.Add(spell);
                            }
                        }
                    }
                    else if (command == "Unlearn")
                    {
                        string spell = tokens[2];

                        if (!heroes.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} doesn't exist.");
                        }
                        else
                        {
                            if (!heroes[name].SpellBooks.Contains(spell))
                            {
                                Console.WriteLine($"{name} doesn't know {spell}.");
                            }
                            else
                            {
                                heroes[name].SpellBooks.Remove(spell);
                            }
                        }
                    }
                }
            }
            heroes = heroes.OrderByDescending(x => x.Value.SpellBooks.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Heroes:");

            foreach (var hero in heroes)
            {
                Console.Write($"== {hero.Key}:");
                int count = 0;

                foreach (var kvp in hero.Value.SpellBooks)
                {
                    count++;
                    if (count == hero.Value.SpellBooks.Count)
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

        class Hero
        {
            //public string HeroName { get; set; }
            public List<string> SpellBooks { get; set; }
        }
    }
}
