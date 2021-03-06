using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatStringFast(input, n));


        }
        //static string RepeatString(String toRepeat, int times)
        //{
        //    string result = "";
        //    for (int i = 0; i < times; i++)
        //    {
        //        result += toRepeat;
        //    }
        //    return result;
        //}
        static string RepeatStringFast(string toRepeat, int times)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                result.Append(toRepeat);
            }
            return result.ToString();
        }
    }
}
