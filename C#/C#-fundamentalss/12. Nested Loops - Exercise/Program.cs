using System;

namespace Nested_Loops___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(counter++ + " ");

                    if (counter > n)
                    {
                        break;
                    }
                }

                if (counter > n)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
