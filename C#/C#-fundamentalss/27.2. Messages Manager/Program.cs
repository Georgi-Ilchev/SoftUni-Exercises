using System;
using System.Collections.Generic;
using System.Linq;

namespace _27._2._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split("=");
                string command = tokens[0];

                if (command == "Add")
                {
                    string username = tokens[1];
                    int sent = int.Parse(tokens[2]);
                    int received = int.Parse(tokens[3]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<int>());
                        users[username].Add(sent);
                        users[username].Add(received);
                    }
                }
                else if (command == "Message")
                {
                    string sender = tokens[1];
                    string receiver = tokens[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender][0] += 1;
                        users[receiver][1] += 1;

                        if (users[sender][0] + users[sender][1] >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.Remove(sender);
                        }
                        if (users[receiver][0] + users[receiver][1] >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            users.Remove(receiver);
                        }
                    }
                }
                else if (command == "Empty")
                {
                    string username = tokens[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }
                    else
                    {
                        if (users.ContainsKey(username))
                        {
                            users.Remove(username);
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {users.Count}");
            users = users.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var name in users)
            {
                string user = name.Key;
                int received = name.Value[1];
                int sent = users[user][0];
                int sum = sent + received;
                Console.WriteLine($"{user} - {sum}");
            }
        }
    }
}
