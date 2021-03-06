using System;

namespace Exercise_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagons = new int[n];
            int allPeople = 0;

            for (int i = 0; i < n; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                allPeople += wagons[i];
            }
            Console.WriteLine(String.Join(' ', wagons));
            Console.WriteLine(allPeople);

        }
    }
}
