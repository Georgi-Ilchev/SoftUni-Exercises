using System;

namespace _16._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Complete")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Make")
                {
                    string upperOrLower = tokens[1];
                    if (upperOrLower == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (upperOrLower == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(tokens[1]);
                    if (count < email.Length && count >= 0)
                    {
                        Console.WriteLine(email.Substring(email.Length - count));
                    }
                    else
                    {
                        Console.WriteLine(email);
                    }
                }
                else if (command == "GetUsername")
                {
                    if (!email.Contains("@"))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        int indexOf = email.IndexOf('@');
                        string username = email.Substring(0, indexOf);
                        Console.WriteLine(username);
                    }
                }
                else if (command == "Replace")
                {
                    char currentChar = char.Parse(tokens[1]);
                    email = email.Replace(currentChar, '-');
                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    for (int i = 0; i < email.Length; i++)
                    {
                        char currentSymbl = email[i];
                        Console.Write((int)currentSymbl + " ");
                    }
                    Console.WriteLine();
                }
                input = Console.ReadLine();
            }
            
        }
    }
}
