using System;
using System.Linq;

namespace _03._Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];
            weekDays[0] = "Monday";
            weekDays[1] = "Tuesday";
            weekDays[2] = "Wednesday";
            weekDays[3] = "Thursday";
            weekDays[4] = "Friday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
