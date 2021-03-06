using System;

namespace exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        if (a + b + c == number && a < b && b < c)
                        {
                            Console.WriteLine($"{a} + {b} + {c} = {number}");
                            counter++;
                        }
                        else if (a * b * c == number && a > b && b > c)
                        {
                            counter++;
                            Console.WriteLine($"{a} * {b} * {c} = {number}");
                        }
                        
                    }
                }
            }
            if (counter==0)
            {
                Console.WriteLine("No!");
            }
            
        }
    }
}
