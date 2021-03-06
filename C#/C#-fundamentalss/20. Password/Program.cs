using System;
using System.Text.RegularExpressions;

namespace _20._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^(.+)>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string firstPart = match.Groups["first"].Value;
                    string secondPart = match.Groups["second"].Value;
                    string thirdPart = match.Groups["third"].Value;
                    string fourthPart = match.Groups["fourth"].Value;

                    Console.WriteLine($"Password: {firstPart}{secondPart}{thirdPart}{fourthPart}");
                }
                else
                {
                    Console.WriteLine($"Try another password!");
                }
            }
        }
    }
}
