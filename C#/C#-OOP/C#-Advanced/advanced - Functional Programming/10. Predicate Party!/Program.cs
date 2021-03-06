using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peoples = Console.ReadLine().Split().ToList();

                        string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] splitted = input.Split();
                string command = splitted[0];
                string[] predicateArgs = splitted.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if (command == "Remove")
                {
                    peoples.RemoveAll(predicate);
                }
                else if (command == "Double")
                {
                    for (int i = 0; i < peoples.Count; i++)
                    {
                        string currentGuest = peoples[i];
                        if (predicate(currentGuest))
                        {
                            peoples.Insert(i + 1, currentGuest);
                            i++;
                        }
                    }
                }
            }
            if (peoples.Count>0)
            {
                string result = string.Join(", ", peoples);
                Console.WriteLine($"{result} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }
        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string type = predicateArgs[0];
            string args = predicateArgs[1];

            Predicate<string> predicate = null;

            if (type == "StartsWith")
            {
                predicate = new Predicate<string>(name => name.StartsWith(args));
            }
            else if (type == "EndsWith")
            {
                predicate = new Predicate<string>(name => name.EndsWith(args));
            }
            else if (type == "Length")
            {
                predicate = new Predicate<string>(name => name.Length == int.Parse(args));
            }
            return predicate;
        }
    }
}
