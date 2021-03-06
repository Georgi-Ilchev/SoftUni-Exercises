using System;

namespace _01._Generic_Box_of_String
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();

                Box<string> box = new Box<string>(currentValue);
                Console.WriteLine(box.ToString());
                //Console.WriteLine(box);
            }
        }
    }
}
