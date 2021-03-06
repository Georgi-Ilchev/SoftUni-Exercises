using System;

namespace Wedding_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            
            for (int mens = 1; mens <= men; mens++)
            {
                if (tables == 0)
                {
                    break;
                }

                for (int womens = 1; womens <= women; womens++)
                {
                    Console.Write($"({mens} <-> {womens}) ");
                    tables--;

                    if (tables == 0)
                    {
                        break;
                    }
                }
            }

        }
    }
}
