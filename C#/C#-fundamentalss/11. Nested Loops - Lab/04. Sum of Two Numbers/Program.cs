using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int k = firstNumber; k <= secondNumber; k++)
                {
                    counter++;
                    if (i + k == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {k} = {magicNumber})");
                        return;
                    }

                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");







        }
    }
}
