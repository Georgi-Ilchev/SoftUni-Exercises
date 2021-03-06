using System;

namespace _09._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int hoursArrivals = int.Parse(Console.ReadLine());
            int minArrivals = int.Parse(Console.ReadLine());
 
            var examTime = (hours * 60) + min;                      //Време на изпит в минути
            var arrivalTime = (hoursArrivals * 60) + minArrivals;   //Впреме на пристигане в минути
            var diffTime = arrivalTime - examTime;
            var secondDiff = examTime - arrivalTime;
 
            if (diffTime <= 59 && diffTime > 0)
            {
                Console.WriteLine("Late");
                Console.WriteLine("{0} minutes after the start", diffTime);
            }
            else if (diffTime >= 60)
            {
                var hour = diffTime / 60;
                var minutes = diffTime % 60;
                Console.WriteLine("Late");
                Console.WriteLine("{0}:{1:00} hours after the start", hour, minutes);  //:f2
            }
            else if (secondDiff == 0)
            {
                Console.WriteLine("On time");
            }
            else if (secondDiff <= 30 && secondDiff > 0)
            {
                Console.WriteLine("On time");
                Console.WriteLine("{0} minutes before the start", secondDiff);
            }
            else if (secondDiff > 30 && secondDiff < 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine("{0} minutes before the start", secondDiff);
            }
 
            else if (secondDiff >= 60)
            {
                var hour = Math.Abs(diffTime / 60);
                var minutes = Math.Abs(diffTime % 60);
                Console.WriteLine("Early");
                Console.WriteLine("{0}:{1:00} hours before the start", hour, minutes); //:f2
               
            }


        }
    }
}
