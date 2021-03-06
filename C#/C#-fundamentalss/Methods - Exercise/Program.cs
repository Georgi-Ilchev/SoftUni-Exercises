using System;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            //Console.WriteLine(SmallestNumber(num1, num2, num3));
            Console.WriteLine(MinNum(num1,num2, num3));
        }

        static int MinNum(int num1, int num2, int num3)
        {
            return Math.Min(Math.Min(num1, num2), num3);
        }
        //static int SmallestNumber (int num1, int num2, int num3)
        //{
        //    int number = 0;
        //    if (num1 < num2 && num1 < num3)
        //    {
        //        number += num1;
        //    }
        //    else if (num2<num1 && num2<num3)
        //    {
        //        number += num2;
        //    }
        //    else if (num3<num1 && num3 < num2)
        //    {
        //        number += num3;
        //    }
        //    else if (num1 == num2 || num1 == num3)
        //    {
        //        number = num1;
        //    }
        //    else if (num2 == num1 || num2 == num3)
        //    {
        //        number = num2;
        //    }
        //    else if (num3 == num1 || num3 == num2)
        //    {
        //        number = num3;
        //    }
        //    return number;
        //}
    }
}
