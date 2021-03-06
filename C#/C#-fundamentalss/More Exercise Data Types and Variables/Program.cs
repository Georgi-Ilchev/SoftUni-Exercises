using System;

namespace More_Exercise_Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "END")
                {
                    break;
                }
                bool isInteger = int.TryParse(word, out int integer);
                bool isDouble = double.TryParse(word, out double floating);
                bool isChar = char.TryParse(word, out char character);
                bool isBoolean = bool.TryParse(word, out bool boolean);

                if (isInteger)
                {
                    Console.WriteLine($"{integer} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{word} is floating point type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{character} is character type");
                }
                else if (isBoolean)
                {
                    Console.WriteLine($"{word} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{word} is string type");
                }
                
                

            }
            
        }
    }
}
