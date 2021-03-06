using System;

namespace _1._1_Match_Tickets
{
    class Program
    {
        private const double VIP = 499.99;
        private const double Normal = 249.99;

        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int peopleCount = int.Parse(Console.ReadLine());

            double budgetLeft = 0.0;
            double ticketSum = 0.0;
            double sumLeft = 0.0;
            double cashNeed = 0.0;


            if (peopleCount >= 1 && peopleCount <= 4)
            {
                if (category == "VIP")
                {
                    budgetLeft = budget * 0.25;
                    ticketSum = VIP * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.75);
                }
                else if (category == "Normal")
                {
                    budgetLeft = budget * 0.25;
                    ticketSum = Normal * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.75);
                }

            }
            else if (peopleCount >= 5 && peopleCount <= 9)
            {
                if (category == "VIP")
                {
                    budgetLeft = budget * 0.40;
                    ticketSum = VIP * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.60);
                }
                else if (category == "Normal")
                {
                    budgetLeft = budget * 0.40;
                    ticketSum = Normal * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.60);
                }

            }
            else if (peopleCount >= 10 && peopleCount <= 24)
            {
                if (category == "VIP")
                {
                    budgetLeft = budget * 0.50;
                    ticketSum = VIP * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.50);
                }
                else if (category == "Normal")
                {
                    budgetLeft = budget * 0.50;
                    ticketSum = Normal * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.50);
                }

            }
            else if (peopleCount >= 25 && peopleCount <= 49)
            {
                if (category == "VIP")
                {
                    budgetLeft = budget * 0.60;
                    ticketSum = VIP * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.40);
                }
                else if (category == "Normal")
                {
                    budgetLeft = budget * 0.60;
                    ticketSum = Normal * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.40);
                }

            }
            else if (peopleCount >= 50)
            {
                if (category == "VIP")
                {
                    budgetLeft = budget * 0.75;
                    ticketSum = VIP * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.25);
                }
                else if (category == "Normal")
                {
                    budgetLeft = budget * 0.75;
                    ticketSum = Normal * peopleCount;
                    sumLeft = Math.Abs(budgetLeft - ticketSum);
                    cashNeed = ticketSum + (budget * 0.25);
                }

            }


            if (budget >= cashNeed)
            {
                Console.WriteLine($"Yes! You have {sumLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sumLeft:f2} leva.");
            }
        }
    }
}
