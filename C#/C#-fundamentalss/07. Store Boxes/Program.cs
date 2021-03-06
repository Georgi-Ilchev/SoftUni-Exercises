using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            double totalPrice = 0.0;

            while (true)
            {
                string input = Console.ReadLine();
                string[] command = input.Split();

                if (input == "end")
                {
                    break;
                }

                string serialNumber = command[0];
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                double itemPrice = double.Parse(command[3]);

                totalPrice = itemQuantity * itemPrice;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.Quantity = itemQuantity;
                box.Price = itemPrice;
                box.TotalPrice = itemPrice * itemQuantity;

                boxes.Add(box);

            }
            List<Box> sortedBox = boxes.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedBox.Reverse();

            foreach (Box box  in sortedBox)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.TotalPrice:f2}");
            }
        }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
