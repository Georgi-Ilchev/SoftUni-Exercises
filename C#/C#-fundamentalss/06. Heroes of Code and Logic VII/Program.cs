using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> hitPoints = new Dictionary<string, int>();
            Dictionary<string, int> manaPoints = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] heroes = input.Split(" ");
                string name = heroes[0];
                int hit = int.Parse(heroes[1]);
                int mana = int.Parse(heroes[2]);

                hitPoints.Add(name, hit);
                manaPoints.Add(name, mana);
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
                        if (manaPoints[name] >= manaNeed)
                        {
                            manaPoints[name] -= manaNeed;
                            Console.WriteLine($"{name} has successfully cast {spell} and now has {manaPoints[name]} MP!");
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

                        hitPoints[name] -= damage;
                        if (hitPoints[name] > 0)
                        {
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hitPoints[name]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                            hitPoints.Remove(name);
                            manaPoints.Remove(name);
                        }
                    }
                    else if (command == "Recharge")
                    {
                        int amount = int.Parse(tokens[2]);

                        if (manaPoints[name] + amount > 200)
                        {
                            amount = 200 - manaPoints[name];
                        }
                        manaPoints[name] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                    else if (command == "Heal")
                    {
                        int amount = int.Parse(tokens[2]);

                        if (hitPoints[name] + amount > 100)
                        {
                            amount = 100 - hitPoints[name];
                        }
                        hitPoints[name] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }
            }
            hitPoints = hitPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in hitPoints)
            {
                int mana = manaPoints[kvp.Key];
                Console.WriteLine($"{kvp.Key}");
                Console.WriteLine($"  HP: {kvp.Value}");
                Console.WriteLine($"  MP: {mana}");
            }
        }
    }
}
