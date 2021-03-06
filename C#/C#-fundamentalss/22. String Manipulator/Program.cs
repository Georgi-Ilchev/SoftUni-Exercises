using System;

namespace _22._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split();
                    string command = tokens[0];

                    if (command == "Change")
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
                    else if (command == "End")
                    {
                        string currentString = tokens[1];
                        if (text.EndsWith(currentString))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else if (command == "Uppercase")
                    {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }
                    else if (command == "FindIndex")
                    {
                        char currentChar = char.Parse(tokens[1]);
                        Console.WriteLine(text.IndexOf(currentChar)); 
                    }
                    else if (command == "Cut")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        //text = text.Remove(0, startIndex);
                        text = text.Substring(startIndex, length);
                        Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
