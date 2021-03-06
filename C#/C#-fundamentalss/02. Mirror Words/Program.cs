using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([@|#])(?<word1>[A-Za-z]{3,})(\1){2}(?<word2>[A-Za-z]{3,})(\1)";
            List<string> sameWord = new List<string>();

            Regex sameWords = new Regex(pattern);
            MatchCollection matches = sameWords.Matches(input);
            foreach (Match item in matches)
            {
                string word1 = item.Groups["word1"].Value.ToString();
                string word2 = item.Groups["word2"].Value.ToString();

                //string word2Reversed = ReverseSecondWord(word2);
                var reversed = string.Concat(word1.Reverse());

                //if (word1 == word2Reversed)
                //{
                //    sameWord.Add(word1 + " <=> " + word2);
                //}

                if (reversed == word2)
                {
                    sameWord.Add(word1 + " <=> " + word2);
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (sameWord.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", sameWord));
            }

        }
        private static string ReverseSecondWord(string secondWord)
        {

            char[] arr = secondWord.ToCharArray();
            arr = arr.Reverse().ToArray();
            secondWord = new string(arr);
            return secondWord;
        }
    }
}
