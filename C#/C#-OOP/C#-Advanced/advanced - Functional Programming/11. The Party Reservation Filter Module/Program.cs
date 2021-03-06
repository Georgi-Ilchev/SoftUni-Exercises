using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peoples = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] splitted = input.Split(";");
                string command = splitted[0];
                string filter = splitted[1];
                string param = splitted[2];

                if (command == "Add filter")
                {
                    filters.Add(filter + " " + param);
                }
                else if (command == "Remove filter")
                {
                    if (filters.Contains(filter + " " + param))
                    {
                        filters.Remove(filter + " " + param);
                    }
                }
            }

            foreach (var item in filters)
            {
                string[] filterArgs = item.Split();
                string filter = string.Empty;
                string param = string.Empty;

                if (filterArgs.Length == 3)
                {
                    filter = filterArgs[0] + " " + filterArgs[1];
                    param = filterArgs[2];
                }
                else if (filterArgs.Length < 3)
                {
                    filter = filterArgs[0];
                    param = filterArgs[1];
                }

                Predicate<string> predicate = GetPredicate(filter, param);
                peoples.RemoveAll(predicate);
            }

            if (peoples.Any())
            {
                Console.WriteLine(string.Join(" ", peoples));
            }
        }
        static Predicate<string> GetPredicate(string filter, string param)
        {
            //Predicate<string> predicate = null;

            //if (filter == "StartsWith")
            //{
            //    predicate = new Predicate<string>(name => name.StartsWith(param));
            //}
            //else if (filter == "EndsWith")
            //{
            //    predicate = new Predicate<string>(name => name.EndsWith(param));
            //}
            //else if (filter == "Length")
            //{
            //    predicate = new Predicate<string>(name => name.Length == int.Parse(param));
            //}
            //else if (filter == "Contains")
            //{
            //    predicate = new Predicate<string>(name => name.Contains(param));
            //}
            //return predicate;
            Predicate<string> predicate = filter switch
            {
                "Starts with" => predicate = new Predicate<string>(name =>
                  name.StartsWith(param)),
                "Ends with" => predicate = new Predicate<string>(name =>
                 name.EndsWith(param)),
                "Length" => predicate = new Predicate<string>(name =>
                 name.Length == int.Parse(param)),
                "Contains" => predicate = new Predicate<string>(name =>
                  name.Contains(param)),
                _ => null
            };
            return predicate;
        }
    }
}
