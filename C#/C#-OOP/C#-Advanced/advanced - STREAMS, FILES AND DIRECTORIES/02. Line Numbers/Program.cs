using System;
using System.IO;
using System.Linq;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            //using (StreamReader reader = new StreamReader("../../../text.txt"))
            //{
            //    using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            //    {
            //        int linesCount = 1;
            //        string line = reader.ReadLine();

            //        while (line != null)
            //        {
            //            int lettersCount = CountOfLetters(line);
            //            int marksCount = CountOfMarks(line);
            //            writer.WriteLine($"Line {linesCount}: {line}({lettersCount})({marksCount})");
            //            line = reader.ReadLine();
            //            linesCount++;
            //        }
            //    }
            //}

            //2
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = CountOfLetters(line);
                int marksCount = CountOfMarks(line);

                newLines[i] = $"Line {i + 1}: {lines[i]}({lettersCount})({marksCount})";
            }

            //3
            //File.WriteAllLines("../../../output.txt", newLines);

            //var lines = File.ReadAllLines(@"..\..\..\text.txt");
            //var punctuations = new char[] { '-', ',', '.', '!', '?', '\'' };

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var line = lines[i];
            //    var letters = 0;
            //    var punctuationMarks = 0;

            //    for (int k = 0; k < line.Length; k++)
            //    {
            //        var currentChar = line[k];

            //        if (char.IsLetter(currentChar))
            //        {
            //            letters++;
            //        }
            //        else if (punctuations.Contains(currentChar))
            //        {
            //            punctuationMarks++;
            //        }
            //    }

            //    lines[i] = $"Line {i + 1}: {line} ({letters})({punctuationMarks})";
            //}

            //File.WriteAllLines(@"..\..\..\output.txt", lines);


            //4
            //string[] lines = File.ReadAllLines(TextFileLocation);
            //StringBuilder builder = new StringBuilder();
            //string defaultLineFormat = "Line: {0}: {1} ({2})({3})";

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string currentLine = lines[i];

            //    int charCount = 0;
            //    int punctuationCount = 0;

            //    for (int j = 0; j < currentLine.Length; j++)
            //    {
            //        if (char.IsLetter(currentLine[j]))
            //        {
            //            charCount++;
            //        }
            //        else if (char.IsPunctuation(currentLine[j]))
            //        {
            //            punctuationCount++;
            //        }
            //    }

            //    string result = string.Format(defaultLineFormat, i + 1, currentLine, charCount, punctuationCount);
            //    builder.AppendLine(result);
            //}

            //File.WriteAllText(OutputFileLocation, builder.ToString().TrimEnd());
        }

        static int CountOfLetters(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (Char.IsLetter(current))
                {
                    counter++;
                }
            }
            return counter;
        }
        static int CountOfMarks(string line)
        {
            int counter = 0;
            char[] punctuationMarks = { '-', ',', '.', '!', '?', '\'',':',';' };

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (punctuationMarks.Contains(current))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

