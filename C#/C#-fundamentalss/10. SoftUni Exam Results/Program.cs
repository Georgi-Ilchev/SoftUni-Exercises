using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> points = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] command = input.Split("-");

                string name = command[0];

                if (command[1] != "banned")
                {
                    if (!points.ContainsKey(name))
                    {
                        points.Add(name, 0);
                    }

                    int currentPoints = int.Parse(command[2]);

                    if (points[name] < currentPoints)
                    {
                        points[name] = currentPoints;
                    }

                    string language = command[1];

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    if (points.ContainsKey(name))
                    {
                        points.Remove(name);
                    }
                }
            }
            Console.WriteLine("Results:");

            foreach (var participant in points.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
