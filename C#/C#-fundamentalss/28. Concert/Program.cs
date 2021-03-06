using System;
using System.Collections.Generic;
using System.Linq;

namespace _28._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandsMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsTimes = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "start of concert")
                {
                    break;
                }
                else
                {
                    List<string> commandList = input.Split("; ").ToList();
                    string command = commandList[0];
                    string bandNAme = commandList[1];

                    if (command == "Add")
                    {
                        string[] members = commandList[2].Split(", ");
                        commandList.RemoveAt(2);

                        for (int i = 0; i < members.Length; i++)
                        {
                            commandList.Add(members[i]);
                        }


                        if (!bandsMembers.ContainsKey(commandList[1]))
                        {
                            bandsMembers.Add(commandList[1], new List<string>());
                            bandsTimes.Add(commandList[1], 0);
                        }

                        for (int i = 2; i < commandList.Count; i++)
                        {
                            if (!bandsMembers[commandList[1]].Contains(commandList[i]))
                            {
                                bandsMembers[commandList[1]].Add(commandList[i]);
                            }
                        }
                    }

                    else if (command == "Play")
                    {
                        if (!bandsMembers.ContainsKey(commandList[1]))
                        {
                            bandsMembers.Add(commandList[1], new List<string>());
                            bandsTimes.Add(commandList[1], 0);
                        }
                        bandsTimes[commandList[1]] += int.Parse(commandList[2]);
                    }
                }
            }

            string bandToBeWriten = Console.ReadLine();

            Console.WriteLine($"Total time: {bandsTimes.Values.Sum()}");

            foreach (var kvp in bandsTimes.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }


            Console.WriteLine(bandToBeWriten);

            foreach (var member in bandsMembers[bandToBeWriten])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
