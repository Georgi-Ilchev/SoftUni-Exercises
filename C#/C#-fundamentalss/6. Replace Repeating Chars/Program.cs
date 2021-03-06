using System;
using System.Linq;
using System.Text;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            input.Distinct()
                .Select(c => c.ToString())
                .ToList()
                .ForEach(c =>
                {
                    while (input.Contains(c + c))
                        input = input.Replace(c + c, c);
                }
            );
            Console.WriteLine(input);
        }
    }
}
