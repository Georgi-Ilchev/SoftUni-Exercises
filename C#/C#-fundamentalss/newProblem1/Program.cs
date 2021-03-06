using System;

namespace newProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] tokens = input.Split('|');
                string command = tokens[0];

                if (command == "Move")
                {
                    int n = int.Parse(tokens[1]);
                    var firstN = message.Substring(0, n);
                    message = message.Remove(0, n);
                    message += firstN;
                    //Console.WriteLine(message);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                    message = message.Insert(index, value);
                    //Console.WriteLine(message);
                }
                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    if (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                        //Console.WriteLine(message);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
