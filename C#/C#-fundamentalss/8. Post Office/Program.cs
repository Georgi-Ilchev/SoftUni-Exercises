using System;
using System.Text.RegularExpressions;

namespace _8._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string pattern1 = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
            Match firstMatch = Regex.Match(firstPart, pattern1);
            string capitals = firstMatch.Groups["capitals"].Value;

            for (int i = 0; i < capitals.Length; i++)
            {
                char startLetter = capitals[i];
                int ASCIIcode = startLetter;

                string pattern2 = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, pattern2);
                int length = int.Parse(secondMatch.Groups["length"].Value);

                string pattern3 = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)";
                Match thirdMatch = Regex.Match(thirdPart, pattern3);
                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }
        }
    }
}
