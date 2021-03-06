using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int first = 1; first <= n; first++)
            {
                for (int second = 1; second <= n; second++)
                {
                    for (int char1 = 'a'; char1 < 'a' + l; char1++)
                    {
                        for (int char2 = 'a'; char2 < 'a' + l; char2++)
                        {
                            int maxNum = Math.Max(first, second);
                            for (int third = maxNum + 1; third <= n; third++)
                            {
                                Console.Write($"{first}{second}{(char)char1}{(char)char2}{third} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
