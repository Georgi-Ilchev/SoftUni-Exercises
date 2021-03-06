using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string[] input = new string[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                long fNum = long.Parse(input[0]);
                long sNum = long.Parse(input[1]);
                long biggerNum = 0;
                if (fNum > sNum)
                {
                    biggerNum = CompareValue(fNum.ToString());
                    Console.WriteLine(biggerNum);
                }
                else
                {
                    biggerNum = CompareValue(sNum.ToString());
                    Console.WriteLine(biggerNum);
                }
            }

           

            
            //{


            //    int n = int.Parse(Console.ReadLine());
            //    string[] input = new string[n];
            //    for (int i = 0; i < n; i++)
            //    {
            //        input = Console.ReadLine()
            //            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //            .ToArray();
            //        string firstNumber = input[0];
            //        string secondNUmber = input[1];

            //        long biggerNumber = 0;

            //        if (firstNumber.Length == secondNUmber.Length)
            //        {
            //            long fNum = CompareValue(firstNumber);
            //            long sNum = CompareValue(secondNUmber);

            //            if (fNum > sNum)
            //            {
            //                Console.WriteLine(fNum);

            //            }
            //            else
            //            {
            //                Console.WriteLine(sNum);

            //            }
            //        }
            //        else
            //        {
            //            if (firstNumber.Length > secondNUmber.Length)
            //            {
            //                biggerNumber = CompareValue(firstNumber);
            //            }
            //            else
            //            {
            //                biggerNumber = CompareValue(secondNUmber);
            //            }

            //            Console.WriteLine(biggerNumber);

            //        }

            //    }


        }

        private static long CompareValue(string n)
        {
            long value = 0;

            int lenght = n.Length;
            long[] nums = new long[lenght];
            long absNumb = long.Parse(n);
            long newNum = Math.Abs(absNumb);
            for (int i = 0; i < newNum.ToString().Length; i++)
            {
                string convertedNum = newNum.ToString();
                nums[i] = long.Parse(convertedNum[i].ToString());

            }

            for (int i = 0; i < nums.Length; i++)
            {
                value += nums[i];
            }

            return value;
        }
    }
}
