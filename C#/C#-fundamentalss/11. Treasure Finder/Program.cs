using System;
using System.Linq;

namespace _11._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input;
            int length = keys.Length;

            while ((input = Console.ReadLine()) != "find")
            {
                char[] inputArgs = input.ToCharArray();
                string result = "";

                result = ExtractDecodedText(keys, inputArgs, result);

                string type, coordinaties;
                ExtractTreasure(result, out type, out coordinaties);

                Console.WriteLine($"Found {type} at {coordinaties}");
            }
        }
        private static string ExtractDecodedText(int[] keys, char[] inputArgs, string result)
        {
            for (int i = 0; i < inputArgs.Length; i++)
            {
                int key;
                char current = (char)inputArgs[i];
                if (i > keys.Length - 1)
                {
                    int indexOfKey = i % keys.Length;
                    key = keys[indexOfKey];
                }
                else
                {
                    key = keys[i];
                }
                char newChar = (char)((int)current - key);
                result += newChar;
            }

            return result;
        }
        private static void ExtractTreasure(string result, out string type, out string coordinates)
        {
            string[] treasureArgs = result.Split("&");
            type = treasureArgs[1];
            string[] coordinateArgs = result.Split(new char[] { '<', '>' });
            coordinates = coordinateArgs[1];
        }
    }
}
