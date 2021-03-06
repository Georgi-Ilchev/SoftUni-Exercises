using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("../../../text.txt");
            {
                int lineCounter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    //line = line.Replace('-', '@');
                    //line = line.Replace(',', '@');
                    //line = line.Replace('.', '@');
                    //line = line.Replace('!', '@');
                    //line = line.Replace('?', '@');
                    if (lineCounter % 2 == 0)
                    {
                        Regex pattern = new Regex("[-,.!?]");
                        line = pattern.Replace(line, "@");
                        var array = line.Split().ToArray().Reverse();
                        Console.WriteLine(string.Join(" ",array));
                    }
                    lineCounter++;
                    line = reader.ReadLine();
                }
            }

            //using var reader = new StreamReader(@"..\..\..\text.txt");
            //var symbols = new char[] { '-', ',', '.', '!', '?' };
            //var counter = 0;
            //var line = reader.ReadLine();

            //while (line != null)
            //{
            //    var sb = new StringBuilder();

            //    if (counter % 2 == 0)
            //    {
            //        for (int i = 0; i < line.Length; i++)
            //        {
            //            var currentChar = line[i];

            //            if (symbols.Contains(currentChar))
            //            {
            //                sb.Append('@');
            //            }
            //            else
            //            {
            //                sb.Append(currentChar);
            //            }
            //        }

            //        var result = sb.ToString().Split();
            //        Console.WriteLine(string.Join(" ", result.Reverse()));
            //    }

            //    counter++;
            //    line = reader.ReadLine();
            //}

        }
    }
}
