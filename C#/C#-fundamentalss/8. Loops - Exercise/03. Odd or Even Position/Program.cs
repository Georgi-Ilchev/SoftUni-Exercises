using System;

namespace _03._Odd_or_Even_Position
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());

                double oddSum = 0.0;
                double oddMin = double.MaxValue;
                double oddMax = double.MinValue;

                double evenSum = 0.0;
                double evenMax = double.MinValue;
                double evenMin = double.MaxValue;

                for (int i = 1; i <= n; i++)
                {
                    double num = double.Parse(Console.ReadLine());

                    if (i % 2 == 0)
                    {
                        evenSum += num;

                        if (num > evenMax)
                        {
                            evenMax = num;
                        }

                        if (num < evenMin)
                        {
                            evenMin = num;
                        }
                    }
                    else
                    {
                        oddSum += num;

                        if (num > oddMax)
                        {
                            oddMax = num;
                        }
                        if (num < oddMin)
                        {
                            oddMin = num;
                        }
                       
                    }
                }


                Console.WriteLine($"OddSum={oddSum:f2},");

                if (oddMin != double.MaxValue)
                {
                    Console.WriteLine($"OddMin={oddMin:f2},");
                }
                else
                {
                    Console.WriteLine($"OddMin=No,");
                }


                if (oddMax != double.MinValue)
                {
                    Console.WriteLine($"OddMax={oddMax:f2},");
                }
                else
                {
                    Console.WriteLine($"OddMax=No,");
                }

                Console.WriteLine($"EvenSum={evenSum:f2},");

                if (evenMin != double.MaxValue)
                {
                    Console.WriteLine($"EvenMin={evenMin:f2},");
                }
                else
                {
                    Console.WriteLine($"EvenMin=No,");
                }


                if (evenMax != double.MinValue)
                {
                    Console.WriteLine($"EvenMax={evenMax:f2}");
                }
                else
                {
                    Console.WriteLine($"EvenMax=No");
                }
            }
        }
    }
