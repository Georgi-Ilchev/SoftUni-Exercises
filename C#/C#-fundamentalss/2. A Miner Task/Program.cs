using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] += quantity;
                }
                else
                {
                    resourceQuantity.Add(resource, quantity);
                }
            }

            foreach (var pair in resourceQuantity)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
