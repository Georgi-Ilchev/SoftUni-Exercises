using System;
using System.Text.RegularExpressions;

namespace _11._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Z][a-z]+ [a-z]+)#";
            string pattern = @"[|](?<name>[A-Z]+)[|]:[#](?<title>[A-Za-z]+ [A-Za-z]+)[#]";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;

                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
            
        }
    }
}
