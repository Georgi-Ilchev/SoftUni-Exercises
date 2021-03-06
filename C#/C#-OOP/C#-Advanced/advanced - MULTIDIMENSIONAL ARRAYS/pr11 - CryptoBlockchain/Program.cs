using System;
using System.Text;
using System.Text.RegularExpressions;

namespace pr11___CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sticked = new StringBuilder();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sticked.Append(Console.ReadLine());
            }

            string pattern = @"\[([^\d\[\]\{\}]*)(?<numbers>[\d]{3,})([^\[\]\{\}]*)\]|\{([^\d\[\]\{\}]*)(?<numbers>[\d]{3,})([^\[\]\{\}]*)\}";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(sticked.ToString());

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Groups["numbers"].Value.Length % 3 != 0)
                {
                    continue;
                }

                var currentBlock = matches[i].Groups["numbers"].Value;
                var numbersLength = matches[i].Groups["numbers"].Value.Length;
                var totalLength = matches[i].Length;

                while (currentBlock.Length > 0)
                {
                    var currentChar = currentBlock.Substring(0, 3);
                    output.Append((char)(int.Parse(currentChar) - totalLength));
                    currentBlock = currentBlock.Substring(3);
                }
            }
            Console.WriteLine(output);
        }
    }
}
