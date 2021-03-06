using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class ConsoleWriter : IWriter
    {
        public static void WriteLine(string textLine)
        {
            Console.WriteLine(textLine);
        }

        void IWriter.WriteLine(string textLine)
        {
            WriteLine(textLine);
        }
    }
}
