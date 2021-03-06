using System;

namespace Loops___Part_2___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int bookCount = int.Parse(Console.ReadLine());

            int counter = 0;
            string currentBook = Console.ReadLine();

            while (bookName != currentBook)
            {

                counter++;
                if (counter == bookCount)
                {
                    break;
                }

                currentBook = Console.ReadLine();
            }

            if (bookName == currentBook)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }

        }
    }
}
