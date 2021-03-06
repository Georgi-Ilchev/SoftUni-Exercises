using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = splitted[0];
                int age = int.Parse(splitted[1]);

                Person p = new Person(name,age);

                peopleHashSet.Add(p);
                peopleSortedSet.Add(p);
            }
            Console.WriteLine($"{peopleHashSet.Count}");
            Console.WriteLine($"{peopleSortedSet.Count}");
        }
    }
}
