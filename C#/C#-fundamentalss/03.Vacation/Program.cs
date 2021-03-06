using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            if (type == "Students")
            {
                if (day == "Friday")
                {
                    if (countOfPeople >= 30)
                    {
                        price = countOfPeople * 8.45 * 0.85;
                    }
                    else
                    {
                        price = countOfPeople * 8.45;
                    }
                }
                else if (day == "Saturday")
                {
                    if (countOfPeople >= 30)
                    {
                        price = countOfPeople * 9.80 * 0.85;
                    }
                    else
                    {
                        price = countOfPeople * 9.80;
                    }
                }
                else if (day == "Sunday")
                {
                    if (countOfPeople >= 30)
                    {
                        price = countOfPeople * 10.46 * 0.85;
                    }
                    else
                    {
                        price = countOfPeople * 10.46;
                    }
                }
            }


            else if (type == "Business")
            {
                if (day == "Friday")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 10.90 - (10 * 10.90);
                    }
                    else
                    {
                        price = countOfPeople * 10.90;
                    }
                }
                else if (day == "Saturday")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 15.60 - (10 * 15.60);
                    }
                    else
                    {
                        price = countOfPeople * 15.60;
                    }
                }
                else if (day == "Sunday")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 16 - (10 * 16);
                    }
                    else
                    {
                        price = countOfPeople * 16;
                    }
                }


            }
            else if (type == "Regular")
            {
                if (day == "Friday")
                {
                    if (countOfPeople > 9 && countOfPeople < 21)
                    {
                        price = countOfPeople * 15 * 0.95;
                    }
                    else
                    {
                        price = countOfPeople * 15;
                    }
                }
                else if (day == "Saturday")
                {
                    if (countOfPeople > 9 && countOfPeople < 21)
                    {
                        price = countOfPeople * 20 * 0.95;
                    }
                    else
                    {
                        price = countOfPeople * 20;
                    }
                }
                else if (day == "Sunday")
                {
                    if (countOfPeople > 9 && countOfPeople < 21)
                    {
                        price = countOfPeople * 22.50 * 0.95;
                    }
                    else
                    {
                        price = countOfPeople * 22.50;
                    }
                    
                }
                
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
