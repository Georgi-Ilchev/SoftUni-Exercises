using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            IfPalindrome();
        }
        static void IfPalindrome()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                string reversedString = string.Empty;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char symbol = input[i];
                    reversedString += symbol;
                }
                if (reversedString == input)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }


    }
}
