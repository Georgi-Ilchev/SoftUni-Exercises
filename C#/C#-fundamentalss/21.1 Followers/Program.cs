using System;
using System.Collections.Generic;
using System.Linq;

namespace _21._1_Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Follower> followers = new Dictionary<string, Follower>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Log out")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(": ");
                    string command = tokens[0];
                    string username = tokens[1];

                    if (command == "New follower")
                    {
                        if (followers.ContainsKey(username))
                        {
                            continue;
                        }
                        else
                        {
                            int likes = 0;
                            int comments = 0;
                            Follower newFollower = new Follower()
                            {
                                Likes = likes,
                                Comments = comments
                            };
                            followers.Add(username, newFollower);
                        }
                    }
                    else if (command == "Like")
                    {
                        int count = int.Parse(tokens[2]);
                        if (followers.ContainsKey(username))
                        {
                            followers[username].Likes += count;
                        }
                        else
                        {
                            int comments = 0;
                            Follower newFollower = new Follower()
                            {
                                Likes = count,
                                Comments = comments
                            };
                            followers.Add(username, newFollower);
                        }
                    }
                    else if (command == "Comment")
                    {
                        if (followers.ContainsKey(username))
                        {
                            followers[username].Comments += 1;
                        }
                        else
                        {
                            int like = 0;
                            Follower newFollower = new Follower()
                            {
                                Likes = like,
                                Comments = 1
                            };
                            followers.Add(username, newFollower);
                        }
                    }
                    else if (command == "Blocked")
                    {
                        if (!followers.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} doesn't exist.");
                        }
                        else
                        {
                            followers.Remove(username);
                        }
                    }
                }
            }
            Console.WriteLine($"{followers.Count} followers");
            followers = followers
                .OrderByDescending(x => x.Value.Likes)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in followers)
            {
                int total = item.Value.Likes + item.Value.Comments;
                Console.WriteLine($"{item.Key}: {total}");
            }
        }
        class Follower
        {
            public int Likes { get; set; }
            public int Comments { get; set; }
        }
    }
}
