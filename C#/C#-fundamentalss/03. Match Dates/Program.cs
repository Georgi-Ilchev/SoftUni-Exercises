using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\d{2})(.)(\w{3})\2([0-9]{4})";
            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match date in matches)
            {
                Console.WriteLine($"Day: {date.Groups[1]}, Month: {date.Groups[3]}, Year: {date.Groups[4]}");
            }
        }
    }
}
