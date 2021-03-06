using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._1_Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Email> emails = new Dictionary<string, Email>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split("->");
                    string command = tokens[0];
                    string username = tokens[1];

                    if (command == "Add")
                    {
                        if (emails.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} is already registered");
                        }
                        else
                        {
                            List<string> sentEmails = new List<string>();
                            Email newEmail = new Email()
                            {
                                SentEmails = sentEmails
                            };
                            emails.Add(username, newEmail);
                        }
                    }
                    else if (command == "Send")
                    {
                        string email = tokens[2];

                        emails[username].SentEmails.Add(email);
                    }
                    else if (command == "Delete")
                    {
                        if (emails.ContainsKey(username))
                        {
                            emails.Remove(username);
                        }
                        else
                        {
                            Console.WriteLine($"{username} not found!");
                        }
                    }
                }
            }
            Console.WriteLine($"Users count: {emails.Count}");

            emails = emails.OrderByDescending(x => x.Value.SentEmails.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var email in emails)
            {
                Console.Write($"{email.Key}");
                Console.WriteLine();
                //int count = 0;

                foreach (var item in email.Value.SentEmails)
                {
                    //count++;
                    if (emails.Count == email.Value.SentEmails.Count)
                    {
                        Console.WriteLine($" - {item}");
                    }
                    else
                    {
                        Console.WriteLine($" - {item}");
                    }
                }
            }
        }
        class Email
        {
            public List<string> SentEmails { get; set; }
        }
    }
}
