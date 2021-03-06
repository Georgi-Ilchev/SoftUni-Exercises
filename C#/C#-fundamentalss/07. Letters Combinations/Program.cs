using System;

namespace _07._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char row1 = char.Parse(Console.ReadLine());
            char row2 = char.Parse(Console.ReadLine());
            char row3 = char.Parse(Console.ReadLine());
            int combination = 0;

            for (char i = row1; i <= row2; i++)
            {
                for (char j = row1; j <= row2; j++)
                {
                    for (char k = row1; k <= row2; k++)
                    {
                        if (i != row3 && j != row3 && k != row3)
                        {
                            Console.Write($"{i}{j}{k} ");
                            combination++;
                        }
                        
                    }
                }
            }
            Console.WriteLine(combination+" ");
        }
    }
}
