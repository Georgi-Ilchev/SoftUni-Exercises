using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> registerd = new Dictionary<string, string>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];


                if (command == "register")
                {
                    string name = input[1];
                    string license = input[2];
                    if (registerd.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registerd[name]}");
                    }
                    else
                    {
                        registerd.Add(name, license);
                        Console.WriteLine($"{name} registered {license} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    string name = input[1];
                    if (!registerd.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        registerd.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }

            }
            foreach (var item in registerd)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
