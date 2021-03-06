using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0;
            int all = 0;
            
            string input = Console.ReadLine();

            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{3,})\1";
            string pattern1 = @"(=|\/)(?<place>[A-Z][A-Za-z]{2,})(\1)";

            List<string> destinations = new List<string>();
            Regex regex = new Regex(pattern1);
            MatchCollection matches = regex.Matches(input);

            if (matches.Count>0)
            {
                foreach (Match item in matches)
                {
                    string destination = item.Groups["place"].Value;
                    destinations.Add(destination);
                    length = destination.Length;
                    all += length;
                }
            }
            
            Console.Write("Destinations: ");
            Console.WriteLine(String.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {all}");
        }
    }
}
