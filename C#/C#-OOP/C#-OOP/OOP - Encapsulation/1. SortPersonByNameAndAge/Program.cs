using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP___Encapsulation
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
                string firstName = splitted[0];
                string lastName = splitted[1];
                int age = int.Parse(splitted[2]);
                Person person = new Person(firstName, lastName, age);
                persons.Add(person);
            }


            persons.OrderBy(p => p.FirstName)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
