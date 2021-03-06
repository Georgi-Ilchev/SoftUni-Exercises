using System;
using System.Collections.Generic;
using System.Linq;

namespace _27._1._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            Dictionary<string, Status> peopleStatus = new Dictionary<string, Status>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }
                string[] cmdArgs = input.Split("=");
                string cmd = cmdArgs[0];
                if (cmd == "Add")
                {
                    string username = cmdArgs[1];
                    int sent = int.Parse(cmdArgs[2]);
                    int recived = int.Parse(cmdArgs[3]);

                    if (!peopleStatus.ContainsKey(username))
                    {
                        peopleStatus.Add(username, new Status(sent, recived));
                    }
                }
                else if (cmd == "Message")
                {
                    string sender = cmdArgs[1];
                    string reciver = cmdArgs[2];

                    if (peopleStatus.ContainsKey(sender) && peopleStatus.ContainsKey(reciver))
                    {
                        peopleStatus[sender].Sent++;
                        peopleStatus[reciver].Recived++;
                        if (peopleStatus[sender].Total >= capacity)
                        {
                            peopleStatus.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (peopleStatus[reciver].Total >= capacity)
                        {
                            peopleStatus.Remove(reciver);
                            Console.WriteLine($"{reciver} reached the capacity!");
                        }
                    }
                }
                else if (cmd == "Empty")
                {
                    string username = cmdArgs[1];
                    if (username == "All")
                    {
                        peopleStatus = new Dictionary<string, Status>();
                    }
                    else if (peopleStatus.ContainsKey(username))
                    {
                        peopleStatus.Remove(username);
                    }
                }
            }
            Console.WriteLine($"Users count: {peopleStatus.Count}");
            foreach (var people in peopleStatus.OrderByDescending(x => x.Value.Recived).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{people.Key} - {people.Value.Total}");
            }
        }
        public class Status
        {
            public int Sent { get; set; }
            public int Recived { get; set; }

            public Status(int sent, int recived)
            {
                this.Sent = sent;
                this.Recived = recived;
            }
            public int Total => this.Sent + this.Recived;

        }
    }
}
