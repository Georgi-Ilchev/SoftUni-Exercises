using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitted = input.Split(", ");
                string command = splitted[0];
                string carNumber = splitted[1];

                if (command == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    cars.Remove(carNumber);
                }


                input = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
