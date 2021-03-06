using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _6._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

            Regex regex = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    result.Append($"invalid ticket{Environment.NewLine}");
                    continue;
                }

                Match leftMatch = regex.Match(ticket.Substring(0, 10));
                Match rightMatch = regex.Match(ticket.Substring(10));
                var minLength = Math.Min(leftMatch.Length, rightMatch.Length);

                if (!leftMatch.Success || !rightMatch.Success)
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                    continue;
                }

                var leftPart = leftMatch.Value.Substring(0, minLength);
                var rightPart = rightMatch.Value.Substring(0, minLength);

                if (leftPart.Equals(rightPart))
                {
                    if (leftPart.Length == 10)
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLength}{leftPart.Substring(0, 1)} Jackpot!{Environment.NewLine}");
                    }
                    else
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLength}{leftPart.Substring(0, 1)}{Environment.NewLine}");
                    }
                }
                else
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
