using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> emails = new Dictionary<string, List<string>>();
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("->");
                    string command = tokens[0];
                    string userName = tokens[1];

                    if (command == "Add")
                    {
                        if (emails.ContainsKey(userName))
                        {
                            Console.WriteLine($"{userName} is already registered");
                        }
                        else
                        {
                            count++;
                            emails[userName] = new List<string>();
                            //emails.Add(username, new List<string>());
                        }
                    }
                    else if (command == "Send")
                    {
                        string email = tokens[2];
                        emails[userName].Add(email);
                    }
                    else if (command == "Delete")
                    {
                        if (emails.ContainsKey(userName))
                        {
                            count--;
                            emails.Remove(userName);
                        }
                        else
                        {
                            Console.WriteLine($"{userName} not found!");
                        }
                    }
                }
            }
            Console.WriteLine($"Users count: {count}");

            //emails = emails.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in emails.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"{item.Key}");
                Console.WriteLine();


                foreach (var kvp in item.Value)
                {
                    if (count == item.Value.Count)
                    {
                        Console.WriteLine($" - {kvp}");
                    }
                    else
                    {
                        Console.WriteLine($" - {kvp}");
                    }
                }
            }
        }
    }
}
