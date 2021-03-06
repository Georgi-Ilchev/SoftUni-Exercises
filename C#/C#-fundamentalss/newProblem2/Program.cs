using System;
using System.Text.RegularExpressions;

namespace newProblem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int allCalories = 0;
            string input = Console.ReadLine();
            string pattern = @"([#|\|])(?<itemName>[A-Za-z]+ ?[A-Za-z]?)\1(?<day>[0-9]{2})\/(?<month>[0-9]{2})\/(?<year>[0-9]{2})\1(?<calories>[0-9]+)\1";
            string pattern1 = @"([#|\|])(?<itemName>[A-Za-z\s?]+[A-Za-z]?)\1(?<day>[0-9]{2})\/(?<month>[0-9]{2})\/(?<year>[0-9]{2})\1(?<calories>[0-9]+)\1";

            Regex regex = new Regex(pattern1);
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                int calories = int.Parse(item.Groups["calories"].Value);
                allCalories += calories;
            }
            Console.WriteLine($"You have food to last you for: {allCalories / 2000} days!");

            foreach (Match item in matches)
            {
                string name = item.Groups["itemName"].Value;
                int day = int.Parse(item.Groups["day"].Value);
                int month = int.Parse(item.Groups["month"].Value);
                int year = int.Parse(item.Groups["year"].Value);
                int calories = int.Parse(item.Groups["calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {day:d2}/{month:d2}/{year}, Nutrition: {calories}");
            }
            
        }
    }
}
