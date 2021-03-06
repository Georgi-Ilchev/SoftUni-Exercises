using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            var kvm = double.Parse(Console.ReadLine());
            var price = kvm * 7.61;
            var discount = price * 0.18;
            var finalPrice = price - discount;     

            Console.WriteLine($"The final price is: {finalPrice:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}
