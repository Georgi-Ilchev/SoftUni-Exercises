using System;

namespace Problem22._Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            double sheetsPaper = double.Parse(Console.ReadLine());
            double singleSheetCover = double.Parse(Console.ReadLine());

            
            double area = sizeOfSide * sizeOfSide * 6;
            double third = Math.Floor(sheetsPaper / 3);

            double sheetsArea = (sheetsPaper * singleSheetCover) - (third * singleSheetCover * 0.75);

            double percentage = sheetsArea / area;
            percentage *= 100;

            Console.WriteLine($"You can cover {percentage:f2}% of the box.");

            
        }
    }
}
