using System;
using System.Text.RegularExpressions;

namespace RegexDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            //Console.WriteLine(regex.IsMatch(input));
            //Console.WriteLine(regex.Match(input).Value);
            //Console.WriteLine(regex.Matches(input).Count);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
        }
    }
}
