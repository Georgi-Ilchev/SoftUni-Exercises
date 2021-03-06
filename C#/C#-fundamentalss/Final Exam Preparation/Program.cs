using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string space = " ";

            while (true)
            {
                string inputMessage = Console.ReadLine();

                if (inputMessage == "Reveal")
                {
                    break;
                }
                else
                {
                    string[] tokens = inputMessage.Split(":|:");
                    string command = tokens[0];

                    if (command == "InsertSpace")
                    {
                        int index = int.Parse(tokens[1]);
                        input = input.Insert(index, space);
                        Console.WriteLine(input);
                    }
                    else if (command == "Reverse")
                    {
                        string substring = tokens[1];
                        if (input.Contains(substring))
                        {
                            input = input.Remove(input.IndexOf(substring), substring.Length);
                            var substring2 = new String(substring.Reverse().ToArray());
                            //var substring3 = String.Concat(substring.Reverse());

                            input += substring2;
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                    }
                    else if (command == "ChangeAll")
                    {
                        string substring = tokens[1];
                        string replacement = tokens[2];

                        while (input.Contains(substring))
                        {
                            input = input.Replace(substring, replacement);
                            Console.WriteLine(input);
                        }
                    }
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
