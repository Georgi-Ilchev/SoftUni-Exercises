using System;

namespace Problem._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] tokens = input.Split(":");
                string command = tokens[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string newString = tokens[2];

                    if (index >= 0 && index < text.Length)
                    {
                        text = text.Insert(index, newString);

                    }
                    Console.WriteLine(text);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex < text.Length &&
                        endIndex >= 0 && endIndex < text.Length)
                    {
                        text = text.Remove(startIndex, (endIndex - startIndex) + 1);
                    }
                    Console.WriteLine(text);
                }
                else if (command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                    }
                    Console.WriteLine(text);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
