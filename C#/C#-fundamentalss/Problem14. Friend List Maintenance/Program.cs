using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem14._Friend_List_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;
            bool isReport = false;
            int blackList = 0;
            int lostName = 0;

            while (!isReport)
            {
                input = Console.ReadLine();
                if (input == "Report")
                {
                    isReport = true;
                    break;
                }
                List<string> command = input.Split(" ").ToList();

                if (command[0] == "Blacklist")
                {
                    string name = command[1];
                    string newName = "Blacklisted";
                    if (friends.Contains(name))
                    {
                        friends[friends.FindIndex(x => x.Equals(command[1]))] = newName;
                        blackList++;
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }

                }
                else if (command[0] == "Error")
                {
                    int index = int.Parse(command[1]);
                    string newName = "Lost";
                    if (friends[index] != "Blacklisted")
                    {
                        if (friends[index] != "Lost")
                        {
                            Console.WriteLine($"{friends[index]} was lost due to an error.");
                            friends[index] = newName;
                            lostName++;
                        }
                    }

                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];

                    if (index >= 0 && index < friends.Count)
                    {
                        Console.WriteLine($"{friends[index]} changed his username to {newName}.");
                        friends[index] = newName;
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blackList}");
            Console.WriteLine($"Lost names: {lostName}");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}
