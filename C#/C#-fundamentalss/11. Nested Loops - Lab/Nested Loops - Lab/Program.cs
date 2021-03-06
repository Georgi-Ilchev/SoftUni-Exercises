using System;

namespace Nested_Loops___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();

            int totalStudent = 0;
            int totalStandard = 0;
            int totalKid = 0;
            

            while (filmName != "Finish")
            {
                int studentCounter = 0;
                int standardCounter = 0;
                int kidCounter = 0;

                int freePositions = int.Parse(Console.ReadLine());

                for (int currentSeat = 1; currentSeat <= freePositions; currentSeat++)
                {

                    string ticketType = Console.ReadLine();

                    if (ticketType == "student")
                    {
                        studentCounter++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardCounter++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidCounter++;
                    }
                    else if (ticketType == "End")
                    {
                        break;
                    }

                }
                totalStudent += studentCounter;
                totalStandard += standardCounter;
                totalKid += kidCounter;

                Console.WriteLine($"{filmName} - {(studentCounter + standardCounter + kidCounter) / (double)freePositions * 100:f2}% full.");

                filmName = Console.ReadLine();
            }
           int totalTickets = totalStandard + totalStudent + totalKid;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{totalStudent / (double)totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{totalStandard / (double)totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{totalKid / (double)totalTickets * 100:f2}% kids tickets.");
        }
    }
}
