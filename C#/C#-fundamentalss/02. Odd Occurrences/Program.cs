using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string item in words)
            {
                string wordInLowerCase = item.ToLower();

                if (counts.ContainsKey(wordInLowerCase))
                {
                    counts[wordInLowerCase]++;
                }
                else
                {
                    counts.Add(wordInLowerCase, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value%2 == 1)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
