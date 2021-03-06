using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _07._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Generate")
                {
                    break;
                }
                else
                {
                    string[] command = input.Split(">>>");
                    string action = command[0];

                    if (action == "Contains")
                    {
                        string substring = command[1];
                        if (key.Contains(substring))
                        {
                            Console.WriteLine($"{key} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                    }
                    else if (action == "Flip")
                    {
                        string upperOrLower = command[1];
                        int startIndex = int.Parse(command[2]);
                        int endIndex = int.Parse(command[3]);

                        if (upperOrLower == "Upper")
                        {
                            //StringBuilder sb = new StringBuilder(key);

                            //for (int i = startIndex; i < endIndex; i++)
                            //{
                            //    sb[i] = char.Parse(sb[i].ToString().ToUpper());
                            //}
                            //Console.WriteLine(sb);
                            var subString = key.Substring(startIndex, endIndex - startIndex);
                            key = Regex.Replace(key, subString, subString.ToUpper());
                        }
                        else
                        {
                            var subString = key.Substring(startIndex, endIndex - startIndex);
                            key = Regex.Replace(key, subString, subString.ToLower());
                        }
                        Console.WriteLine(key);
                    }
                    else if (action == "Slice")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        key = key.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(key);
                    }
                }
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
