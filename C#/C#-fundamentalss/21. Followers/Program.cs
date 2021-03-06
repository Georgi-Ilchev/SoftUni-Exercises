using System;
using System.Collections.Generic;
using System.Linq;

namespace _21._Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Log out")
                {
                    break;
                }

                string[] tokens = command.Split(": ").ToArray();
                string name = tokens[1];

                if (tokens[0] == "New follower")
                {
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new List<int>());
                        users[name].Add(0);
                        users[name].Add(0);
                    }

                }
                else if (tokens[0] == "Like")
                {
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new List<int>());
                        users[name].Add(0);
                        users[name].Add(0);
                    }
                    users[name][0] += int.Parse(tokens[2]);
                }
                else if (tokens[0] == "Comment")
                {
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new List<int>());
                        users[name].Add(0);
                        users[name].Add(0);
                    }
                    users[name][1] += 1;
                }
                else if (tokens[0] == "Blocked")
                {
                    if (!users.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        users.Remove(name);
                    }
                }
            }

            Console.WriteLine($"{users.Count} followers");
            //users = users.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var name in users.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))// тук сортираме
            {
                int total = name.Value[0] + name.Value[1]; // смятаме тотал
                Console.WriteLine($"{name.Key}: {total}"); // принтираме
            }
        }
    }
}
