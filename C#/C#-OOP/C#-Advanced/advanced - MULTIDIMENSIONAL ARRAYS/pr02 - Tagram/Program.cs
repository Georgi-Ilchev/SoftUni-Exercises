using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace pr02___Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] splitted = command
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToArray();

                if (command.Contains("ban"))
                {
                    string[] splitt = splitted[0].Split().ToArray();
                    string usernameBan = splitt[1];
                    data.Remove(usernameBan);
                }
                else
                {
                    string userName = splitted[0];
                    string tag = splitted[1];
                    int likes = int.Parse(splitted[2]);

                    if (!data.ContainsKey(userName))
                    {
                        data.Add(userName, new Dictionary<string, int>());
                    }

                    if (!data[userName].ContainsKey(tag))
                    {
                        data[userName].Add(tag, likes);
                    }
                    else
                    {
                        data[userName][tag] += likes;
                    }
                }

                command = Console.ReadLine();
            }
            foreach (var username in data.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine($"{username.Key}");
                foreach (var item in username.Value)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
        }
        //public class Users
        //{
        //    public Users(string username, string tag, int likes)
        //    {
        //        this.Username = username;
        //        this.Tag = tag;
        //        this.Likes = likes;
        //    }
        //    public string Username { get; set; }
        //    public string Tag { get; set; }
        //    public int Likes { get; set; }
        //}
    }
}
