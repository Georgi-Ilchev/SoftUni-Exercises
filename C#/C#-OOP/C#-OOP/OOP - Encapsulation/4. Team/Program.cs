using System;
using System.Collections.Generic;

namespace _4._Team
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] splitted = Console.ReadLine().Split();
                try
                {
                    string firstName = splitted[0];
                    string lastName = splitted[1];
                    int age = int.Parse(splitted[2]);
                    decimal salary = decimal.Parse(splitted[3]);
                    Person person = new Person(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Team team = new Team("SoftUni");
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
