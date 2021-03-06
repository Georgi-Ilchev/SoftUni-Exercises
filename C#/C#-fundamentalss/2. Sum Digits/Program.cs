using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            //int number = int.Parse(Console.ReadLine());

            //int sum = 0;

            //while (number != 0)
            //{
            //    sum += number % 10;
            //    number /= 10;
            //}
            //Console.WriteLine(sum);

            string num = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                sum += int.Parse(num[i].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
