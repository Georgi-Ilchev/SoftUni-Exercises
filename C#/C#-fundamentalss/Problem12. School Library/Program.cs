using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem12._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split('&').ToList();
            bool isDone = false;

            while (!isDone)
            {
                List<string> command = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (command[0] == "Done")
                {
                    isDone = true;
                    continue;
                }
                else if (command[0] == "Add Book")
                {
                    string bookName = command[1];
                    if (books.Contains(bookName))
                    {
                        continue;
                    }
                    else
                    {
                        books.Insert(0, bookName);
                    }
                }
                else if (command[0] == "Take Book")
                {
                    string bookName = command[1];

                    if (books.Contains(bookName))
                    {
                        books.Remove(bookName);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Swap Books")
                {
                    string book1 = command[1];
                    string book2 = command[2];

                    if (books.Contains(book1) && books.Contains(book2))
                    {
                        int index1 = books.IndexOf(book1);
                        int index2 = books.IndexOf(book2);

                        string temp1 = books[index1];
                        string temp2 = books[index2];

                        books[index1] = temp2;
                        books[index2] = temp1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Insert Book")
                {
                    string bookName = command[1];
                    books.Add(bookName);
                }
                else if (command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index <= books.Count)
                    {
                        Console.WriteLine($"{books[index]}");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", books));
        }
    }
}
