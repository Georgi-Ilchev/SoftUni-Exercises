using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Problem28._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string eMail = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Make":
                        if (command[1] == "Upper")
                        {
                            eMail = eMail.ToUpper();
                        }
                        else if (command[1] == "Lower")
                        {
                            eMail = eMail.ToLower();
                        }
                        Console.WriteLine(eMail);
                        break;
                    case "GetDomain":
                        int count = int.Parse(command[1]);
                        if (count < eMail.Length && count >= 0)
                        {
                            Console.WriteLine(eMail.Substring(eMail.Length - count));
                        }
                        else
                        {
                            Console.WriteLine(eMail);
                        }
                        break;
                    case "GetUsername":
                        if (eMail.Contains('@'))
                        {
                            int indexOf = eMail.IndexOf('@');
                            string username = eMail.Substring(0, indexOf);
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The email {eMail} doesn't contain the @ symbol.");
                        }
                        break;
                    case "Replace":
                        char currentChar = char.Parse(command[1]);
                        eMail = eMail.Replace(currentChar, '-');
                        Console.WriteLine(eMail);
                        break;
                    case "Encrypt":
                        for (int i = 0; i < eMail.Length; i++)
                        {
                            char currentSymbol = eMail[i];
                            Console.Write((int)currentSymbol + " ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
