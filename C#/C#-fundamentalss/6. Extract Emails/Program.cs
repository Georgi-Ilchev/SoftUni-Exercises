using System;
using System.Text.RegularExpressions;

namespace _6._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<!-|_|\.)[a-z]+[\._-]?\w+@[a-zA-z]+[\.-][a-zA-Z]+[\.-]?\w+([\.-]\w+)?";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
