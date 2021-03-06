using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem24._Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;
            var print = new List<string>();

            while (!(input = Console.ReadLine()).Contains("Print"))
            {
                string[] command = input.Split();

                if (command[0] == "Join")
                {
                    string name = command[1];
                    frogs.Add(name);
                }
                else if (command[0] == "Jump")
                {
                    string name = command[1];
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, name);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Dive")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "First")
                {
                    int count = int.Parse(command[1]);
                    if (count >= frogs.Count)
                    {
                        count = frogs.Count;
                    }
                    print = frogs.Take(count).Select(x => x).ToList();
                    Console.WriteLine(string.Join(" ", print));
                }
                else if (command[0] == "Last")
                {
                    int count = int.Parse(command[1]);
                    if (count >= frogs.Count)
                    {
                        count = frogs.Count;
                    }
                    frogs.Reverse();
                    print = frogs.Take(count).Select(x => x).ToList();
                    print.Reverse();
                    frogs.Reverse();
                    Console.WriteLine(string.Join(" ", print));
                }
                
            }

            if (input.Split(" ")[1] == "Reversed")
            {
                frogs.Reverse();
            }
            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");

        }
    }
}
