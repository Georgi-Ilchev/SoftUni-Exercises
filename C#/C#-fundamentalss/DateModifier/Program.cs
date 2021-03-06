using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DateModifier dataModifie = new DateModifier();
            var result = dataModifie.GetDaysDifference(startDate, endDate);
            Console.WriteLine(result);
        }
    }
}
