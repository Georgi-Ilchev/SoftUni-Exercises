using System;

namespace test4
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            for (int i = 1; i <= stop; i++)
            {
                int down = int.Parse(Console.ReadLine());
                int up = int.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    passengers += 2;
                }
                else
                {
                    passengers -= 2;
                }
                passengers -= down;
                passengers += up;
            }

            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
