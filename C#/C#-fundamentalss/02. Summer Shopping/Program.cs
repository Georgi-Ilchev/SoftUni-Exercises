using System;

namespace _02._Summer_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());

            double umbrellaPrice = towelPrice * 2 / 3;
            double flipFlopsPrice = umbrellaPrice * 0.75;
            double bag = (towelPrice + flipFlopsPrice) * 1 / 3;

            double totalPrice = towelPrice + umbrellaPrice + flipFlopsPrice + bag;
            double sumAfterDiscount = totalPrice - (totalPrice * percentDiscount/100);

            if (budget>=sumAfterDiscount)
            {
                Console.WriteLine($"Annie's sum is {sumAfterDiscount:f2} lv. She has {budget-sumAfterDiscount:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {sumAfterDiscount:f2} lv. She needs {sumAfterDiscount -budget:f2} lv. more.");
            }
        }
    }
}
