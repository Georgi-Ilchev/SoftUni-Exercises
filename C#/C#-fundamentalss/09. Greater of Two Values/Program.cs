using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            Console.WriteLine(GetMax(type, first, second));
        }
        static string GetMax(string type, string first, string second)
        {
            int result1 = 0;
            int result2 = 0;
            if (type == "int")
            {
                result1 = int.Parse(first);
                result2 = int.Parse(second);
            }
            else if (type == "char")
            {
                result1 = char.Parse(first);
                result2 = char.Parse(second);
            }
            else if (type == "string")
            {
                int compare = first.CompareTo(second);
                if (compare > 0)
                {
                    return first;
                }
                else
                {
                    return second;
                }
            }
            if (result1 > result2)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

    }
}
