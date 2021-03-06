using System;
using System.Text.RegularExpressions;

namespace _17._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"[U][\$](?<name>[A-Z][a-z]{2,})[U][\$][P][\@][\$](?<pass>[A-Za-z]{5,}[0-9]+)[P][\@][\$]";
            Regex regex = new Regex(pattern);
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    counter++;
                    Console.WriteLine("Registration was successful");
                    string name = match.Groups["name"].Value;
                    string password = match.Groups["pass"].Value;

                    Console.WriteLine($"Username: {name}, Password: {password}");
                }
                else
                {
                    Console.WriteLine($"Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {counter}");
        }
    }
}
