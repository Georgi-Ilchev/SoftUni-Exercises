using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _7._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(([^\d]+)(\d+))";
            int count = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string message = match.Groups[2].Value;
                int repeat = int.Parse(match.Groups[3].Value);

                for (int i = 0; i < repeat; i++)
                {
                    output.Append(message.ToUpper());
                }
            }
            count = output.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(output);
        }
    }
}
