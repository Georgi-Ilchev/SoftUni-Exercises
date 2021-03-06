using System;
using System.Collections.Generic;

namespace _13._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            List<string> comments = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine())!="end of comments")
            {
                string comment = input;
                comments.Add(comment);
            }
            Console.WriteLine($"<h1>\n\t{title}\n</h1>");
            Console.WriteLine($"<article>\n\t{content}\n</article>");

            foreach (var item in comments)
            {
                Console.WriteLine($"<div>\n\t{item}\n</div>");
            }
        }
    }
}
