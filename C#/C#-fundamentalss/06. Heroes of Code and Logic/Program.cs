using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Heroes_of_Code_and_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string name = tokens[0];
                int hitPoints = int.Parse(tokens[1]);
                int manaPoints = int.Parse(tokens[2]);

                Hero newHero = new Hero()
                {
                    HitPoints = hitPoints,
                    ManaPoints = manaPoints
                };
                heroes.Add(name, newHero);
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
                    string[] tokens = input.Split(" - ");
                    string command = tokens[0];
                    string name = tokens[1];

                    if (command == "CastSpell")
                    {
                        int manaNeed = int.Parse(tokens[2]);
                        string spell = tokens[3];

                        if (heroes[name].ManaPoints >= manaNeed)
                        {
                            heroes[name].ManaPoints -= manaNeed;
                            Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name].ManaPoints} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                        }
                    }
                    else if (command == "TakeDamage")
                    {
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];

                        heroes[name].HitPoints -= damage;

                        if (heroes[name].HitPoints > 0)
                        {
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HitPoints} HP left!");
                        }
                        else
                        {
                            heroes.Remove(name);
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                        }
                    }
                    else if (command == "Recharge")
                    {
                        int amount = int.Parse(tokens[2]);

                        if (heroes[name].ManaPoints + amount > 200)
                        {
                            amount = 200 - heroes[name].ManaPoints;
                        }
                        heroes[name].ManaPoints += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                    else if (command == "Heal")
                    {
                        int amount = int.Parse(tokens[2]);
                        if (heroes[name].HitPoints + amount > 100)
                        {
                            amount = 100 - heroes[name].HitPoints;
                        }
                        heroes[name].HitPoints += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }
            }
            heroes = heroes.OrderByDescending(x => x.Value.HitPoints).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HitPoints}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}");
            }
        }
        class Hero
        {
            public int HitPoints { get; set; }
            public int ManaPoints { get; set; }
        }
    }
}
