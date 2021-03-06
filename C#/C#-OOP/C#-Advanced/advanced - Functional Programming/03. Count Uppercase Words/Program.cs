using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            string[] input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }

            //2
            var input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s[0] == s.ToUpper()[0])
                .ToArray();

            Console.WriteLine(string.Join("\n", input1));
        }
    }
}
