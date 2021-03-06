using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];

                    if (command == "TakeOdd")
                    {
                        //string temporary = "";
                        StringBuilder oddChars = new StringBuilder();

                        for (int i = 1; i < password.Length; i += 2)
                        {
                            //temporary += password[i];
                            oddChars.Append(password[i]);
                        }

                        //password = temporary;
                        password = oddChars.ToString();
                        Console.WriteLine(password);
                    }
                    else if (command == "Cut")
                    {
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        string firstPart = password.Substring(0, index);
                        string secondPart = password.Substring(index + length);

                        password = firstPart + secondPart;
                        Console.WriteLine(password);
                    }
                    else if (command == "Substitute")
                    {
                        string substring = tokens[1];
                        string substitute = tokens[2];
                        string current = string.Empty;

                        if (password.Contains(substring))
                        {
                            current = password.Replace(substring, substitute);
                            password = current;
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
