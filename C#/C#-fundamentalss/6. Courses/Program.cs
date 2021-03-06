using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string courseName = input.Split(" : ")[0];
                string studentName = input.Split(" : ")[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }
            }

            foreach (var pair in courses.OrderByDescending(course => course.Value.Count))
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.Count);
                List<string> students = pair.Value;
                students.Sort();

                foreach (var student in students)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}
