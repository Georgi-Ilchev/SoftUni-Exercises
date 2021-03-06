using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            Dictionary<string, string> contestPass = new Dictionary<string, string>();

            while (firstLine != "end of contests")
            {
                string[] command = firstLine.Split(':');
                string contest = command[0];
                string passwordForContest = command[1];
                contestPass.Add(contest, passwordForContest);
                firstLine = Console.ReadLine();
            }

            string secondLine = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();

            while (secondLine != "end of submissions")
            {
                string[] command = secondLine.Split("=>");
                string contest = command[0];
                string password = command[1];
                string username = command[2];
                int points = int.Parse(command[3]);

                if (!contestPass.ContainsKey(contest) ||contestPass[contest] != password)
                {
                    secondLine = Console.ReadLine();
                    continue;
                }

                if (!submissions.ContainsKey(username))
                {
                    submissions[username] = new Dictionary<string, int> { { contest, points } };
                }

                if (!submissions[username].ContainsKey(contest))
                {
                    submissions[username].Add(contest, points);
                }

                if (submissions[username][contest] < points)
                {
                    submissions[username][contest] = points;
                }
                secondLine = Console.ReadLine();
            }

            Dictionary<string, int> usersTootalPoints = new Dictionary<string, int>();
            foreach (var kvp in submissions)
            {
                usersTootalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int maxPoints = usersTootalPoints
                .Values
                .Max();

            foreach (var kvp in usersTootalPoints)
            {
                if (kvp.Value == maxPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");
                }
            }

            Console.WriteLine("Ranking:");

            foreach (var kvp in submissions)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(string.Join(Environment.NewLine, kvp.Value
                    .OrderByDescending(x => x.Value)
                    .Select(a => $"#  {a.Key} -> {a.Value}")
                    ));
            }
        }
    }
}
