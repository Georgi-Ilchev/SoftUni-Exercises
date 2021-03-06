using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _19._Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sign up")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split();
                    string command = tokens[0];
                    if (command == "Case")
                    {
                        string upperOrLower = tokens[1];
                        if (upperOrLower == "upper")
                        {
                            userName = userName.ToUpper();
                            Console.WriteLine(userName);
                        }
                        else if (upperOrLower == "lower")
                        {
                            userName = userName.ToLower();
                            Console.WriteLine(userName);
                        }
                    }
                    else if (command == "Reverse")
                    {
                        //int startIndex = int.Parse(tokens[1]);
                        //int endIndex = int.Parse(tokens[2]);

                        //var subString = userName.Substring(startIndex, (endIndex - startIndex) + 1);
                        //char[] currChar = subString.ToCharArray();
                        //string reversed = string.Empty;

                        //if (startIndex >= 0 && startIndex < userName.Length)
                        //{
                        //    if (endIndex >= 0 && endIndex < userName.Length)
                        //    {
                        //        for (int i = currChar.Length - 1; i > -1; i--)
                        //        {
                        //            reversed += currChar[i];
                        //        }

                        //        Console.WriteLine(reversed);
                        //    }
                        //}

                        //int startIndex = int.Parse(tokens[1]);
                        //int endIndex = int.Parse(tokens[2]);

                        //if (startIndex >= 0 && startIndex < userName.Length && endIndex > startIndex && endIndex < userName.Length)
                        //{
                        //    int startIndexes = userName.IndexOf(userName[startIndex]);
                        //    int endIndexes = userName.LastIndexOf(userName[endIndex]);
                        //    int length = endIndexes - startIndexes + 1;
                        //    string word = userName.Substring(startIndexes, (endIndex - startIndex) + 1);
                        //    Console.WriteLine(string.Join("", word.Reverse()));
                        //}

                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        if (startIndex >= 0 &&
                            endIndex > startIndex &&
                            endIndex < userName.Length)
                        {

                            string word = userName.Substring(startIndex, (endIndex - startIndex) + 1);
                            Console.WriteLine(string.Join("", word.Reverse()));
                        }

                    }
                    else if (command == "Cut")
                    {
                        string subString = tokens[1];
                        if (userName.Contains(subString))
                        {
                            userName = Regex.Replace(userName, subString, "");
                            Console.WriteLine(userName);
                        }
                        else
                        {
                            Console.WriteLine($"The word {userName} doesn't contain {subString}.");
                        }
                    }
                    else if (command == "Replace")
                    {
                        char currChar = char.Parse(tokens[1]);

                        if (userName.Contains(currChar))
                        {
                            userName = userName.Replace(currChar, '*');
                            Console.WriteLine(userName);
                        }

                    }
                    else if (command == "Check")
                    {
                        char currChar = char.Parse(tokens[1]);

                        if (userName.Contains(currChar))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {currChar}.");
                        }
                    }
                }
            }
        }
    }
}
