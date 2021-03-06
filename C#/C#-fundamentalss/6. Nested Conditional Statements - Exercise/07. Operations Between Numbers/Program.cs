using System;

namespace _07._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operatorSymbol = Console.ReadLine();

            if (operatorSymbol == "+" || operatorSymbol == "-" || operatorSymbol == "*")
            {
                int result = 0;

                if (operatorSymbol == "+")
                {
                    result = num1 + num2;
                }
                else if (operatorSymbol == "-")
                {
                    result = num1 - num2;
                }
                else if (operatorSymbol == "*")
                {
                    result = num1 * num2;
                }

                string evenOrodd = " ";

                if (result % 2 == 0)
                {
                    evenOrodd = "even";
                }
                else
                {
                    evenOrodd = "odd";
                }
                Console.WriteLine($"{num1} {operatorSymbol} {num2} = {result} - {evenOrodd}");
            }
            else if (operatorSymbol == "/")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} / {num2} = {num1 * 1.0 / num2:f2}");
                }

            }
            else if (operatorSymbol == "%")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
                }

            }

        }
    }
}
