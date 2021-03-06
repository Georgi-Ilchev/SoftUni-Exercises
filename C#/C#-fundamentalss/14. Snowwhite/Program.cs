using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] command = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string color = command[1];
                int physics = int.Parse(command[2]);

                string ID = name + ":" + color;
                if (!dwarfs.ContainsKey(ID))
                {
                    dwarfs.Add(ID, physics);
                }
                else
                {
                    dwarfs[ID] = Math.Max(dwarfs[ID], physics);
                }
            }

            foreach (var dwarf in dwarfs
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                .Count()))
            {
                Console.WriteLine("({0}) {1} <-> {2}",
                    dwarf.Key.Split(':')[1],
                    dwarf.Key.Split(':')[0],
                    dwarf.Value);
            }
        }
    }
}
