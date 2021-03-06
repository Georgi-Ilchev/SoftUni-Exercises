using System;

namespace _10._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int start = (int)Math.Min(first, second);
            int end = (int)Math.Max(first, second);

            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                int currentChar = (int)text[i];
                if (currentChar>start && currentChar < end)
                {
                    sum += currentChar;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
