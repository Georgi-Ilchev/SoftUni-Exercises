using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            while (numbers.Length !=1)
            {
                int[] newArr = new int[numbers.Length - 1];

                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = numbers[i] + numbers[i + 1];
                }
                numbers = newArr;
            }
            Console.WriteLine(String.Join(" ", numbers));
            
        }
    }
}
