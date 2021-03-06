using System;

namespace DATA_TYPES_AND_VARIABLES
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            float kilometeres = meters * 0.001f;
            Console.WriteLine($"{kilometeres:f2}");
        }
    }
}
