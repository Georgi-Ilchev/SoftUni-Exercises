using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());

            int spendCounter = 0;
            int daysCount = 0;
           
            while (balance < neededMoney)
            {
                string type = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCount++;

                if (type == "save")
                {
                    balance += money;
                    spendCounter = 0;
                }
                else
                {
                    balance -= money;
                    spendCounter++;

                    if (balance <0)
                    {
                        balance = 0;
                    }
                       
                }

                if (spendCounter == 5)
                {
                    break;
                }
                                
            }

            if (balance >= neededMoney )
            {
                Console.WriteLine($"You saved the money for {daysCount} days.") ;
            }

            if (spendCounter == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(daysCount);
            }


        }
    }
}
