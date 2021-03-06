using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(firstNum, operation, secondNum));
        }
        static double Calculate(double firstNum, string operation, double secondNum)
        {
            double result = 0.0;
            switch (operation)
            {
                case "+": result = firstNum + secondNum; break;
                case "-": result = firstNum - secondNum; break;
                case "*": result = firstNum * secondNum; break;
                case "/": result = firstNum / secondNum; break;
            }
            return result;
        }
    }
}
