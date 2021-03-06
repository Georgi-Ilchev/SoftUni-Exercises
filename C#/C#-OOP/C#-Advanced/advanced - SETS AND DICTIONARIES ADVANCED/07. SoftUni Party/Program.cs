using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> peoples = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    input = Console.ReadLine();
                    while (input != "END")
                    {
                        if (VIP.Contains(input))
                        {
                            VIP.Remove(input);
                        }
                        else
                        {
                            peoples.Remove(input);
                        }
                        input = Console.ReadLine();
                    }
                    break;
                }
                else
                {

                    if (input.Length > 0 && char.IsDigit(input[0]))
                    {
                        VIP.Add(input);
                    }
                    else
                    {
                        peoples.Add(input);
                    }
                }
            }

            Console.WriteLine(peoples.Count + VIP.Count);

            foreach (var item in VIP)
            {
                Console.WriteLine(item);
            }
            foreach (var item in peoples)
            {
                Console.WriteLine(item);
            }
        }
    }
}
