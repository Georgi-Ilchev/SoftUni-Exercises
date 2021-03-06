using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pr12___Hitlists
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] splitted = input.Split(new char[] { '=', ';' });
                string name = splitted[0];
                bool isExist = false;

                foreach (var item in people)
                {
                    if (item.Name == name)
                    {
                        AddPersonInfo(splitted, item);
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    Person person = new Person(name);
                    people.Add(person);
                    AddPersonInfo(splitted, person);
                }
            }

            string[] searchedPerson = Console.ReadLine().Split();

            for (int i = 0; i < people.Count; i++)
            {
                var current = people[i];
                if (current.Name == searchedPerson[1])
                {
                    Console.WriteLine(current);
                    if (current.InfoIndex >= target)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {target - current.InfoIndex} more info.");
                    }
                    break;
                }
            }
        }
        private static void AddPersonInfo(string[] splitted, Person person)
        {
            for (int i = 1; i < splitted.Length; i++)
            {
                var info = splitted[i].Split(':');
                int infoIndex = 0;

                if (!person.Info.ContainsKey(info[0]))
                {
                    person.Info[info[0]] = info[1];
                    infoIndex = info[0].Length + info[1].Length;
                }
                else
                {
                    int value = person.Info[info[0]].Length;
                    person.Info[info[0]] = info[1];
                    infoIndex = info[1].Length - value;
                }

                person.CalcIndex(infoIndex);
            }
        }

        public class Person
        {
            public Person(string name)
            {
                this.Name = name;
                this.InfoIndex = 0;
                this.Info = new Dictionary<string, string>();
            }
            public string Name { get; set; }
            public Dictionary<string, string> Info { get; set; }
            public int InfoIndex { get; set; }

            public void CalcIndex(int value)
            {
                this.InfoIndex += value;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Info on {this.Name}:");
                foreach (var kvp in this.Info.OrderBy(x => x.Key))
                {
                    sb.AppendLine($"---{kvp.Key}: {kvp.Value}");
                }
                sb.AppendLine($"Info index: {this.InfoIndex}");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
