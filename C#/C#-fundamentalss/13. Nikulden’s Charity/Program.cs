using System;
using System.Text.RegularExpressions;

namespace _13._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Replace")
                {
                    char currentChar = char.Parse(tokens[1]);
                    char newChar = char.Parse(tokens[2]);

                    text = text.Replace(currentChar, newChar);
                    Console.WriteLine(text);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex < text.Length)
                    {
                        if (endIndex >= 0 && endIndex < text.Length)
                        {
                            text = text.Remove(startIndex, (endIndex - startIndex) + 1);
                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command == "Make")
                {
                    string upperOrLower = tokens[1];
                    if (upperOrLower == "Upper")
                    {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }
                    else if (upperOrLower == "Lower")
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                }
                else if (command == "Check")
                {
                    string str = tokens[1];
                    if (text.Contains(str))
                    {
                        Console.WriteLine($"Message contains {str}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {str}");
                    }
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    string current = string.Empty;
                    int sum = 0;

                    if (startIndex >= 0 && startIndex < text.Length)
                    {
                        if (endIndex >= 0 && endIndex < text.Length)
                        {
                            //text = text.Remove(startIndex, (endIndex - startIndex) + 1);
                            current = text.Substring(startIndex, (endIndex - startIndex) + 1);

                            foreach (char ch in current)
                            {
                                sum += (int)ch;
                                //Console.WriteLine((int)ch);
                            }
                            Console.WriteLine(sum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
