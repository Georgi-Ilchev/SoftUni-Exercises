using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> pool = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] command = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string player = command[0];
                    string position = command[1];
                    int skill = int.Parse(command[2]);

                    if (!pool.ContainsKey(player))
                    {
                        pool.Add(player, new Dictionary<string, int>());
                        pool[player].Add(position, skill);
                    }
                    else
                    {
                        if (pool[player].ContainsKey(position) && pool[player][position] < skill)
                        {
                            pool[player][position] = skill;
                        }
                        else if (!pool[player].ContainsKey(position))
                        {
                            pool[player].Add(position, skill);
                        }
                    }
                }
                else if (input.Contains("vs"))
                {
                    string[] command = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string player1 = command[0];
                    string player2 = command[1];

                    if (pool.ContainsKey(player1) && pool.ContainsKey(player2))
                    {
                        foreach (var item in pool[player1])
                        {
                            if (pool[player2].ContainsKey(item.Key))
                            {
                                int totalPoints1 = pool[player1].Values.Sum();
                                int totalPoints2 = pool[player2].Values.Sum();

                                if (totalPoints1 > totalPoints2)
                                {
                                    pool.Remove(player2);
                                    break;
                                }
                                else if (totalPoints1 < totalPoints2)
                                {
                                    pool.Remove(player1);
                                    break;
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            pool = pool
                .OrderByDescending(kvp => kvp.Value.Values
                .Sum())
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in pool)
            {
                Console.WriteLine($"{kvp.Key.Trim()}: {kvp.Value.Values.Sum()} skill");
                var currentPlayer = kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(a => a.Key, a => a.Value);
                foreach (var pps in currentPlayer)
                {
                    Console.WriteLine($"- {pps.Key.Trim()} <::> {pps.Value}");
                }
            }
        }
    }
}
