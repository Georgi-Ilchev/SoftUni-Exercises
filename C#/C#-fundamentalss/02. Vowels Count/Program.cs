using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(VowerCount(input));
            //char[] vowels = new char[]; {'a', 'o', 'e', 'i'
            //if (vowels.Contains(input[i]))
            //{
            //counter++;
            //}
        }
        static int VowerCount(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a')
                {
                    counter++;
                }
                if (input[i] == 'e')
                {
                    counter++;
                }
                if (input[i] == 'i')
                {
                    counter++;
                }
                if (input[i] == 'o')
                {
                    counter++;
                }
                if (input[i] == 'u')
                {
                    counter++;
                }

            }
            return counter;
        }
    }
}
