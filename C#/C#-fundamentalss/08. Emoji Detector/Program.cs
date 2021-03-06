using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            //string pattern = @"([\::]{2}|[\**]{2})[A-Z][a-z]{2,}\1";
            string pattern = @"(\*\*|::)[A-Z][a-z]{2,}\1";
            string diggitPattern = @"(?<number>\d)";

            List<Match> emojies = Regex.Matches(text, pattern).ToList();
            List<Match> digits = Regex.Matches(text, diggitPattern).ToList();

            List<string> finalEmojies = new List<string>();

            long coolnesFactor = 1;
            var coolnes = 0;

            foreach (var item in digits)
            {
                coolnesFactor *= int.Parse(item.Groups["number"].Value);
            }
            foreach (var emoji in emojies)
            {
                for (int i = 0; i < emoji.Value.Length; i++)
                {
                    if (char.IsLetter(emoji.Value[i]))
                    {
                        coolnes += emoji.Value[i];
                    }
                }
                if (coolnes > coolnesFactor)
                {
                    finalEmojies.Add(emoji.Value);
                }
                coolnes = 0;
            }

            Console.WriteLine($"Cool threshold: {coolnesFactor}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");
            if (finalEmojies.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, finalEmojies));
            }
        }
    }
}
