using System;

namespace _4._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int key = int.Parse(Console.ReadLine());

            int interval = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < interval; i++)
            {
                char c = char.Parse(Console.ReadLine());

                int keyword = (int)c + key;

                message += (char)keyword;
            }

            Console.WriteLine(message);
        }
    }
}
