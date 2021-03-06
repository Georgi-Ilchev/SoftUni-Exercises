using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace worm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //string pattern = @"s:(?<sender>[^;]+ ?);r:(?<receiver>[^;]+ ?);m--(?<message>"[A-Za-z]+")";
            string pattern = @"s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--\W(?<message>[A-Za-z\s]+)\W";

            int dataSum = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(pattern);
                Match correctMatch = regex.Match(input);

                string sender = correctMatch.Groups["sender"].Value;
                string receiver = correctMatch.Groups["receiver"].Value;
                string message = correctMatch.Groups["message"].Value;

                string validSender = string.Empty;
                string validReceiver = string.Empty;

                if (!correctMatch.Success)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < sender.Length; j++)
                    {
                        if (char.IsLetter(sender[j]) || char.IsWhiteSpace(sender[j]))
                        {
                            validSender += sender[j];
                        }
                        else if (char.IsDigit(sender[j]))
                        {
                            dataSum += int.Parse(sender[j].ToString());
                        }
                    }

                    for (int k = 0; k < receiver.Length; k++)
                    {
                        if (char.IsLetter(receiver[k]) || char.IsWhiteSpace(receiver[k]))
                        {
                            validReceiver += receiver[k];
                        }
                        else if (char.IsDigit(receiver[k]))
                        {
                            dataSum += int.Parse(receiver[k].ToString());
                        }
                    }
                }
                Console.WriteLine($"{validSender} says \"{message}\" to {validReceiver}");
            }
            Console.WriteLine($"Total data transferred: {dataSum}MB");
        }
    }
}
