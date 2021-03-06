using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public  class ConsoleReader : IReader
    {
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        string IReader.ReadLine()
        {
            return ReadLine();
        }
    }
}
