using System;
using System.Collections.Generic;

namespace _3._Validation_of_Data
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            decimal parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
