using System;
using System.Collections.Generic;
using System.Linq;

namespace _24._1_Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, People> peoples = new Dictionary<string, People>();
            string input = Console.ReadLine();

            while (input != "Results")
            {
                string[] tokens = input.Split(":");
                string command = tokens[0];

                if (command == "Add")
                {
                    string person = tokens[1];
                    int health = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);

                    if (!peoples.ContainsKey(person))
                    {
                        People newPeople = new People()
                        {
                            Health = health,
                            Energy = energy
                        };

                        peoples.Add(person, newPeople);
                    }
                    else
                    {
                        peoples[person].Health += health;
                    }
                }
                else if (command == "Attack")
                {
                    string attacker = tokens[1];
                    string defender = tokens[2];
                    int damage = int.Parse(tokens[3]);

                    if (peoples.ContainsKey(attacker) && peoples.ContainsKey(defender))
                    {
                        peoples[defender].Health -= damage;
                        peoples[attacker].Energy -= 1;

                        if (peoples[defender].Health <= 0)
                        {
                            peoples.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }

                        if (peoples[attacker].Energy <= 0)
                        {
                            peoples.Remove(attacker);
                            Console.WriteLine($"{attacker} was disqualified!");
                        }
                    }
                }
                else if (command == "Delete")
                {
                    string username = tokens[1];

                    if (username == "All")
                    {
                        peoples.Clear();
                    }

                    if (peoples.ContainsKey(username))
                    {
                        peoples.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"People count: {peoples.Count}");

            peoples = peoples.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var person in peoples)
            {
                Console.WriteLine($"{person.Key} - {person.Value.Health} - {person.Value.Energy}");
            }
        }
        class People
        {
            public int Health { get; set; }
            public int Energy { get; set; }
        }
    }
}
