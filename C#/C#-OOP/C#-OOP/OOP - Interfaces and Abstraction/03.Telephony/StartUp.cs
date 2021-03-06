using System;

namespace OOP___Interfaces_and_Abstraction
{
    public class StartUp
    {
        static void Main(string[] args)
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
                else
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
