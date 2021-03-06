using System;
using System.Collections.Generic;

namespace _05._Generic_Count_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<string> values = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();
                values.Add(currentValue);
            }

            string value = Console.ReadLine();

            Box<string> box = new Box<string>(values);

           int counter =  box.GetCountOfGreaterValues(value);
            Console.WriteLine(counter);
        }
    }
}
