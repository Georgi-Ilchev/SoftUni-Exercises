using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());
            PrintCharsBetweenTwoChars(inputOne, inputTwo);
        }
        static void PrintCharsBetweenTwoChars(char inputOne, char inputTwo)
        {
            int start = Math.Min(inputOne, inputTwo);
            int end = Math.Max(inputOne, inputTwo);

            for (int i = ++start; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
            
        }
    }
}
