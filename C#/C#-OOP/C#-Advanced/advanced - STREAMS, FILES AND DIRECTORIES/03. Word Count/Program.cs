using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { '-', '.', ',', '?', '!', ' ' };

            string[] words = File.ReadAllLines("../../../words.txt");
            string[] text = File.ReadAllText("../../../text.txt").ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (words[i] == text[j])
                    {
                        counter++;
                    }
                }
                wordsCount.Add(words[i], counter);
                counter = 0;
            }

            foreach (var word in wordsCount)
            {
                File.AppendAllText("../../../actualResult.txt", $"{word.Key}-{word.Value}" + Environment.NewLine);
            }

            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("../../../expectedRestul.txt", $"{item.Key}-{item.Value}" + Environment.NewLine);
            }


            //2

            //    var dict = new Dictionary<string, int>();

            //    var words = File.ReadAllLines(@"..\..\..\words.txt");
            //    ReadWords(words, dict);

            //    var text = File.ReadAllText(@"..\..\..\text.txt")
            //        .Split(new char[] { '-', ',', '.', '!', '?', '\'', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    FindRepeatableWords(dict, text);

            //    string result = RepeatableWordsAsString(dict);
            //    File.WriteAllText(@"..\..\..\actualResult.txt", result);

            //    dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //    var orderedResult = RepeatableWordsAsString(dict);

            //    File.WriteAllText(@"..\..\..\expectedResult.txt", orderedResult);
            //}

            //private static string RepeatableWordsAsString(Dictionary<string, int> dict)
            //{
            //    var sb = new StringBuilder();

            //    foreach (var (word, times) in dict)
            //    {
            //        sb.AppendLine($"{word} - {times}");
            //    }

            //    return sb.ToString().TrimEnd();
            //}
            //private static void FindRepeatableWords(Dictionary<string, int> dict, string[] text)
            //{
            //    foreach (var word in text)
            //    {
            //        var currentWord = word.ToLower();

            //        if (dict.ContainsKey(currentWord))
            //        {
            //            dict[currentWord]++;
            //        }
            //    }
            //}

            //private static void ReadWords(string[] words, Dictionary<string, int> dict)
            //{
            //    foreach (var word in words)
            //    {
            //        var currWord = word.ToLower();

            //        if (!dict.ContainsKey(currWord))
            //        {
            //            dict.Add(currWord, 0);
            //        }
            //    }
            //}

            //3
            //Dictionary<string, int> wordCount = new Dictionary<string, int>();
            //string[] words = File.ReadAllLines("../../../words.txt");
            //string[] sentences = File.ReadAllLines(TextFileLocation);

            //for (int i = 0; i < sentences.Length; i++)
            //{
            //    string[] currentSentenceWords = sentences[i].ToLower().Split();
            //    Regex regex = new Regex(@"\w+");

            //    foreach (var word in currentSentenceWords)
            //    {
            //        // We need only the word itself, not the surrounding marks next to it (if there is such).
            //        // Thus, a regex pattern is required.
            //        string matchedWord = regex.Match(word).Value;

            //        if (words.Any(x => x == matchedWord))
            //        {
            //            if (!wordCount.ContainsKey(matchedWord))
            //            {
            //                wordCount[matchedWord] = 0;
            //            }

            //            wordCount[matchedWord]++;
            //        }
            //    }
            //}

            //StringBuilder result = new StringBuilder();

            //foreach (var item in wordCount.OrderByDescending(x => x.Key))
            //{
            //    result.AppendLine($"{item.Key} - {item.Value}");
            //}

            //File.WriteAllText("../../../actualResult.txt", result.ToString().TrimEnd());

            //result.Clear();

            //foreach (var item in wordCount.OrderByDescending(x => x.Value))
            //{
            //    result.AppendLine($"{item.Key} - {item.Value}");
            //}

            //File.WriteAllText("../../../expectedResult.txt", result.ToString().TrimEnd());
        }
    }
}
