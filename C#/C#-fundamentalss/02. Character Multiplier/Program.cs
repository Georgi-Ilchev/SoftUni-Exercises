using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Console.WriteLine(CharMultiplier(input[0],input[1]));

            //string str1 = input[0];
            //string str2 = input[1];

            //int minLen = Math.Min(str1.Length, str2.Length);
            //int maxLen = Math.Max(str1.Length, str2.Length);
            //int sum = 0;

            //for (int i = 0; i < minLen; i++)
            //{
            //    sum += MultiplyCharsASCII(str1[i], str2[i]);
            //}

            //if (str1.Length != str2.Length)
            //{
            //    string longerInput = str1.Length > str2.Length ? longerInput = str1 : longerInput = str2;

            //    for (int i = minLen; i < maxLen; i++)
            //    {
            //        sum += longerInput[i];
            //    }
            //}
            //Console.WriteLine(sum);

        }

        static int MultiplyCharsASCII(char let1, char let2)
        {
            int multiply = let1 * let2;
            return multiply;
        }

        static int CharMultiplier(string first,string second) 
        {
            int sum = 0;
            string longest = string.Empty;
            string shortest = string.Empty;

            if (first.Length>second.Length)
            {
                longest = first;
                shortest = second;
            }
            else
            {
                longest = second;
                shortest = first;
            }

            for (int i = 0; i < shortest.Length; i++)
            {
                sum += first[i] * second[i];
            }

            for (int il = shortest.Length; il < longest.Length; il++)
            {
                sum += longest[il];
            }

            return sum;
        }
    }
}
