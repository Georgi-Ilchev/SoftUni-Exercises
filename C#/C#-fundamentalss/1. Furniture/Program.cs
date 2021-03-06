using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            //string pattern = @">>([A-Z][a-z]+|[A-Z][A-Z]+)<<([0-9]*.?[0-9]*)!([0-9])";
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quant>\d+)";

            var items = new List<string>();
            double totalPrice = 0.0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

                if (m.Success)
                {
                    var name = m.Groups["name"].Value;
                    var price = double.Parse(m.Groups["price"].Value);
                    var quant = int.Parse(m.Groups["quant"].Value);
                    items.Add(name);
                    totalPrice += price * quant;
                }
            }
            Console.WriteLine($"Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, items)}");
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
