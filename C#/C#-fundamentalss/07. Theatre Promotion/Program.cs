using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (day == "Weekday")
            {
                if (age >= 0 && age <= 18 || age >= 65 && age <= 122)
                {
                    price = 12;
                }
                else if (age>18 && age <65)
                {
                    price = 18;
                }
            }

            if (day == "Weekend")
            {
                if (age >= 0 && age <= 18 || age >= 65 && age <= 122)
                {
                    price = 15;
                }
                else if (age > 18 && age < 65)
                {
                    price = 20;
                }
            }

            if (day == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                else if (age >= 65 && age <= 122)
                {
                    price = 10;
                }
                else if (age > 18 && age < 65)
                {
                    price = 12;
                }
            }
            if (price!=0)
            {
                Console.WriteLine($"{price}$");
            }
            else if (true)
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
