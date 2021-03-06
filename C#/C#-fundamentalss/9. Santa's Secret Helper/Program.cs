using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _9._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int ASCIIcode = 0;
            StringBuilder names = new StringBuilder();
            List<string> kids = new List<string>();

            while (true)
            {
                string newInput = string.Empty;
                if (input == "end")
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        char curr = input[i];
                        int currAsNum = int.Parse(curr.ToString());
                        currAsNum -= key;
                        newInput += currAsNum;
                    }
                }
                input = Console.ReadLine();
            }

            var newASCIIcode = names.ToString();
            string pattern3 = @"@(?<name>[A-Za-z]*)[^\@\-\!\:\>]*[A-Za-z]!(?<behaviour>[G])!";
            string pattern1 = @"@(?<name>[A - Za - z] +)([\-^@!:>] +)?![G]!";
            string pattern = @"@(?<name>[A-Za-z]+)[^-@!:>]*\w*!(?<behavior>[A-Z])!";
            Match match = Regex.Match(newASCIIcode, pattern);

            if (true)
            {
                string name = match.Groups["name"].Value;
                kids.Add(name);
            }

            foreach (string name in kids)
            {
                Console.WriteLine(name);
            }
        }
    }
}
