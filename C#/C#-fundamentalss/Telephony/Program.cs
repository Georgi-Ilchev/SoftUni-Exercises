using System;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urlAdresses = Console.ReadLine().Split();

            Smartphone smartPhone = new Smartphone("Smartphone");
            StationaryPhone stationary = new StationaryPhone();

            foreach (var phone in phoneNumbers)
            {
                if (phone.Length == 7)
                {
                    Console.WriteLine(stationary.Call(phone));
                }
                else if (phone.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(phone));
                }
            }

            foreach (var url in urlAdresses)
            {
                Console.WriteLine(smartPhone.Browse(url));
            }
        }
    }
}
