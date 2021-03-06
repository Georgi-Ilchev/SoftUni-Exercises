using System;

namespace exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double counter2 = 0.0;
            double counter3 = 0.0;
            double counter4 = 0.0;

            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p11 = 0.0;
            double p22 = 0.0;
            double p33 = 0.0;
            //int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0 && number % 3 == 0 && number % 4 == 0)
                {
                    counter2++;
                    counter3++;
                    counter4++;
                }
                else if (number % 2 == 0 && number % 4 == 0)
                {
                    counter2++;
                    counter4++;
                }
                else if (number % 2 == 0 && number % 3 == 0)
                {
                    counter2++;
                    counter3++;
                }
                else if (number % 2 == 0)
                {
                    counter2++;
                }
                else if (number %3==0)
                {
                    counter3++;
                }
                
                
            }
            p1 = counter2 / n;
            p2 = counter3 / n;
            p3 = counter4 / n;

            p11 = p1 * 100;
            p22 = p2 * 100;
            p33 = p3 * 100;
            Console.WriteLine($"{p11:f2}%");
            Console.WriteLine($"{p22:f2}%");
            Console.WriteLine($"{p33:f2}%");
        }
    }
}
