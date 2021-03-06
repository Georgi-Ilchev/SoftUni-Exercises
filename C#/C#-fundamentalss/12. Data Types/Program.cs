using System;

namespace _12._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                Console.WriteLine(IntMethod(input));
            }
            else if (input == "real")
            {
                double result = (DoubleMethod(input));
                Console.WriteLine($"{result:f2}");
            }
            else if (input == "string")
            {
                StringMethod();
            }
        }
        static int IntMethod(string input)
        {
            int intInput = int.Parse(Console.ReadLine());
            int result = intInput * 2;
            return result;
        }
        static double DoubleMethod(string input)
        {
            double doubleInput = double.Parse(Console.ReadLine());
            double result = doubleInput * 1.5;
            return result;
        }
        static void StringMethod()
        {
            string stringInput = Console.ReadLine();
            Console.WriteLine($"${stringInput}$");
            
        }

    }
}
