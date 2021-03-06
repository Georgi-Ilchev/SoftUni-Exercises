using System;

namespace _25._String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split();
                    string command = tokens[0];

                    if (command == "Translate")
                    {
                        char currentChar = char.Parse(tokens[1]);
                        char replacement = char.Parse(tokens[2]);

                        text = text.Replace(currentChar, replacement);
                        Console.WriteLine(text);
                    }
                    else if (command == "Includes")
                    {
                        string currentString = tokens[1];
                        if (text.Contains(currentString))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else if (command == "Start")
                    {
                        string currentString = tokens[1];
                        if (text.StartsWith(currentString))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else if (command == "Lowercase")
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                    else if (command == "FindIndex")
                    {
                        char currentChar = char.Parse(tokens[1]);
                        Console.WriteLine(text.LastIndexOf(currentChar)); 
                    }
                    else if (command == "Remove")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int count = int.Parse(tokens[2]);

                        text = text.Remove(startIndex, count);
                        Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
