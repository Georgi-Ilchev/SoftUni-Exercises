using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string title = command[0];
                string content = command[1];
                string author = command[2];

                var article = new Article(title, content, author);
                articles.Add(article);
            }

            string orderBy = Console.ReadLine();

            switch (orderBy)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
            }
            Console.WriteLine(string.Join(Environment.NewLine,articles));
        }


        public class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
