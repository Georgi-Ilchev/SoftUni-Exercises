using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"^%(?<customer>[A-Z][a-z]+)%<(?<product>w+)>\|(?<count>d+)\|(?<price>[0-9]*\.?[0-9]*?)\$";
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double income = 0.0;

            while (true)
            {
                string text = Console.ReadLine();

                if (text == "end of shift")
                {
                    break;
                }
                if (Regex.IsMatch(text, pattern))
                {
                    Match m = Regex.Match(text, pattern);

                    var customer = m.Groups["customer"].Value;
                    string product = m.Groups["product"].Value;
                    int count = int.Parse(m.Groups["count"].Value);
                    double price = double.Parse(m.Groups["price"].Value);
                    double money = price * count;

                    Console.WriteLine($"{customer}: {product} - {money:f2}");
                    income += money;
                }
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}

