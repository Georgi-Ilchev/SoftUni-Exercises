using System;

namespace _10.__Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());

            int counter = 0;
            int originalN = n;

            while (n >= m)
            {
                if (2*n == originalN && y > 0)
                {
                    n /= y;

                    if (n<m)
                    {
                        break;
                    }
                }
                n -= m;
                counter++;
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
