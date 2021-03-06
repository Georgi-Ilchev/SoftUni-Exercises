using System;
using System.Text.RegularExpressions;

namespace _23._Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(\*|@)(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>[A-Za-z]{1})\]\|\[(?<second>[A-Za-z]{1})\]\|\[(?<third>[A-Za-z]{1})\]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                //Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string command = match.Groups["tag"].Value;
                    char group1 = char.Parse(match.Groups["first"].Value);
                    char group2 = char.Parse(match.Groups["second"].Value);
                    char group3 = char.Parse(match.Groups["third"].Value);

                    Console.WriteLine($"{command}: {(int)group1} {(int)group2} {(int)group3}");

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
