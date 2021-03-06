using System;
using System.Text.RegularExpressions;

namespace _14._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\!(?<command>[A-Z][a-z]{2,})\!\:\[(?<output>[a-zA-z]{8,})\]";
            //string patern = @"[!](?<command>[A-Z][a-z]{2,})[!]:\[(?<output>[A-Z][A-Za-z]{8,})\]";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string output = match.Groups["output"].Value;
                    Console.Write(command + ":" + " ");

                    foreach (var ch in output)
                    {
                        int result = ch;
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"The message is invalid");
                }
            }
        }
    }
}
