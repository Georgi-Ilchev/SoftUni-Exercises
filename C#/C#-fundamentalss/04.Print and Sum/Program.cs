using System;

namespace _04.Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numb1 = int.Parse(Console.ReadLine());
            int numb2 = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = numb1; i <= numb2; i++)
            {
                sum += i;
                Console.Write($" {i}");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");


        }
    }
}
