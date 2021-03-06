using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();

            const string END_COMMAND = "END";
            string command;

            while ((command = Console.ReadLine()) != END_COMMAND)
            {
                string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = splitted[0];
                int age = int.Parse(splitted[1]);
                string town = splitted[2];

                Person person = new Person(name, age, town);
                peoples.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person comparedPerson = peoples[n - 1];

            int samePerson = 0;

            foreach (Person person1 in peoples)
            {
                if (person1.CompareTo(comparedPerson) == 0)
                {
                    samePerson++;
                }
            }

            if (samePerson == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notSamePersonCount = peoples.Count - samePerson;

                Console.WriteLine($"{samePerson} {notSamePersonCount} {peoples.Count}");
            }
        }
    }
}
