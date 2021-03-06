using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(MiddleChar(input));
        }
        static string MiddleChar(string input)
        {
            int length = input.Length;
            string result = "";
            if (length % 2 == 1)
            {
                result = input[input.Length / 2].ToString();
            }
            else
            {
                result = input[input.Length / 2 - 1] + input[input.Length / 2].ToString();
            }
            return result;
        }
    }
}
