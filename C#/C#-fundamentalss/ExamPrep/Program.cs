using System;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double expenses = double.Parse(Console.ReadLine());

            double casual = income * 0.3;
            double saving = income - (expenses + casual);
            double savedMoney = months * saving;
            double percent = (saving / income) * 100;

            Console.WriteLine($"She can save {percent:f2}%");
            Console.WriteLine($"{savedMoney:f2}");

        }
    }
}
