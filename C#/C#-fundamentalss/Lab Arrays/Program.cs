using System;

namespace Lab_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[7]
            //input.split;
            { "Monday", "Tuesday" ,"Wednesday", "Thursday", "Friday", "Saturday","Sunday"};

            int day = int.Parse(Console.ReadLine());


            if (day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[day - 1]);
            }
        }
    }
}
