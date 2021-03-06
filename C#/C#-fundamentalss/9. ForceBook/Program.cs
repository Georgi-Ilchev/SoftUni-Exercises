using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> book = new Dictionary<string, List<string>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] command = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Contains("|"))
                {
                    string side = command[0];
                    string user = command[1];

                    if (!book.ContainsKey(side))
                    {
                        book[side] = new List<string>();
                    }
                    if (!book.Values.Any(l=>l.Contains(user)))
                    {
                        book[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = command[0];
                    string side = command[1];

                    foreach (var item in book)
                    {
                        if (item.Value.Contains(user))
                        {
                            item.Value.Remove(user);
                        }
                    }

                    if (!book.ContainsKey(side))
                    {
                        book[side] = new List<string>();
                    }
                    book[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            Dictionary<string, List<string>> orderedBook = book.Where(kvp => kvp.Value.Count > 0)
                             .OrderByDescending(kvp => kvp.Value.Count)
                             .ThenBy(kvp => kvp.Key)
                             .ToDictionary(a => a.Key, b => b.Value);

            foreach (var svp in orderedBook)
            {
                string currentSide = svp.Key;
                List<string> currentUsers = svp.Value.OrderBy(a => a).ToList();
                Console.WriteLine($"Side: {currentSide}, Members: {currentUsers.Count}");

                foreach (var user in currentUsers)
                {
                    Console.WriteLine($"! {user}");
                }
            }

        }
    }
}
