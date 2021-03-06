using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _29._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<name>[A-Z][a-z\s']+):(?<song>[A-Z\s]+)$";
            string otherPatern = @"[a-z]";
            string otherPatern1 = @"[A-Z]";

            Regex regex = new Regex(pattern);
            Regex other = new Regex(otherPatern);
            Regex other1 = new Regex(otherPatern1);

            List<string> splitComand = new List<string>();
            List<char> cript = new List<char>();

            while (true)
            {
                string input = Console.ReadLine();
                splitComand.RemoveRange(0, splitComand.Count);
                cript.RemoveRange(0, cript.Count);

                if (input == "end")
                {
                    break;
                }
                splitComand = input.Split(":").ToList();
                if (regex.IsMatch(input))
                {
                    string name = regex.Match(input).Groups["name"].Value;
                    string song = regex.Match(input).Groups["song"].Value;
                    if (name != splitComand[0])
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i].ToString() == " ")
                        {
                            cript.Add(' ');
                        }
                        else if (input[i].ToString() == "'")
                        {
                            cript.Add((char)(39));
                        }
                        else if (input[i].ToString() == ":")
                        {
                            cript.Add('@');
                        }
                        else
                        {
                            int result = input[i] + splitComand[0].Length;
                            if (other1.IsMatch(((char)input[i]).ToString()))
                            {
                                if (result > 90)
                                {
                                    result = 64 + (input[i] + splitComand[0].Length - 90);
                                }
                            }
                            if (other.IsMatch(((char)input[i]).ToString()))
                            {
                                if (result > 122)
                                {
                                    result = 96 + (input[i] + splitComand[0].Length - 122);
                                }
                            }
                            cript.Add((char)(result));
                        }
                    }
                    Console.WriteLine($"Successful encryption: {string.Join(null, cript)}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
