using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem._2
{
    class Program
    {
        static void Main(string[] args)
        {

            int length = 0;
            int all = 0;


            string input = Console.ReadLine();

            string pattern = @"(=|\/)(?<place>[A-Z][A-Za-z]{2,})(\1)";

            Regex regex = new Regex(pattern);
            List<string> valid = new List<string>();

            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    string word = item.Groups["place"].Value.ToString();
                    valid.Add(word);
                    length = word.Length;
                    all += length;
                }
            }

            Console.Write("Destinations: ");
            Console.WriteLine(String.Join(", ", valid));

            Console.WriteLine($"Travel Points: {all}");
        }
    }
}