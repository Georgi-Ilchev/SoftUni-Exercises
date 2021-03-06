using System;
using System.Text.RegularExpressions;

namespace _26._Message_Decrypter___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern1 = @"(\$|\%)(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>[0-9]{1})\]\|\[(?<second>[0-9]{1})\]\|\[(?<third>[0-9]{1})\]\|$";
            string pattern = @"^([$%])(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>\d+)\]\|\[(?<second>\d+)\]\|\[(?<third>\d+)\]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string command = match.Groups["tag"].Value;
                    int group1 = int.Parse(match.Groups["first"].Value);
                    int group2 = int.Parse(match.Groups["second"].Value);
                    int group3 = int.Parse(match.Groups["third"].Value);

                    Console.WriteLine($"{command}: {(char)group1}{(char)group2}{(char)group3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
