using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] splitted = input.Split(":");
                string contestName = splitted[0];
                string contestPass = splitted[1];
                passwords.Add(contestName, contestPass);

                input = Console.ReadLine();
            }


            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            string secondInput = Console.ReadLine();
            while (secondInput != "end of submissions")
            {
                string[] splitted = secondInput.Split("=>");
                string contest = splitted[0];
                string password = splitted[1];
                string username = splitted[2];
                int points = int.Parse(splitted[3]);

                if (passwords.ContainsKey(contest) && passwords[contest] == password)
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                        students[username].Add(contest, points);
                    }
                    else
                    {
                        if (!students[username].ContainsKey(contest))
                        {
                            students[username].Add(contest, points);
                        }
                        else if (students[username][contest] < points)
                        {
                            students[username][contest] = points;
                        }
                    }
                }
                secondInput = Console.ReadLine();
            }
            students = PrintResults(students);
        }
        private static Dictionary<string, Dictionary<string, int>> PrintResults(Dictionary<string, Dictionary<string, int>> students)
        {
            var bestStudents = students.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);
            var bestPointsStudent = bestStudents.Take(1);
            foreach (var item in bestPointsStudent)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking:");
            students = students.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var (key, value) in students)
            {
                Console.WriteLine($"{key}");
                foreach (var item in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }

            return students;
        }
    }
}
