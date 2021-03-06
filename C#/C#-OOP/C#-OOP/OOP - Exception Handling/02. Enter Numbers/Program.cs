using System;
using System.ComponentModel;
using System.Globalization;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = ReadNumber(/*start, end*/);
                    if (array[i] <= start || array[i] > 100)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                    i--;
                    continue;
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Number must be bigger than {start} and smaller than {end}!");
                    i--;
                    continue;
                }
                start = array[i];
            }
        }

        public static int ReadNumber(/*int start, int end*/)
        {
            string input = Console.ReadLine();
            int num;

            while (!int.TryParse(input, out num))
            {
                throw new FormatException();
            }
            return num;
        }
    }

}
