using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            //string.Empty - празен стринг
            string username = Console.ReadLine();
            string password = "";
            

            for (int i = username.Length -1; i >= 0; i--)
            {
                password += username[i];
            }

            string input = Console.ReadLine();
            int count = 1;

            while (input != password)
            {
                if (count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
                count++;

                
            }
            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
