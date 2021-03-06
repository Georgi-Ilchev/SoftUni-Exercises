using System;

namespace _02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = RecursiveFactorial(n);
            Console.WriteLine(result);
        }
        private static int RecursiveFactorial(int n)
        {
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n * RecursiveFactorial(n - 1);
            }
        }
    }
}
