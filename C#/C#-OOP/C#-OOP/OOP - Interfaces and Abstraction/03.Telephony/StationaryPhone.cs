using System;
using System.Linq;
using System.Text;

namespace OOP___Interfaces_and_Abstraction
{
    class StationaryPhone : ICalable
    {
        public string Call(string phone)
        {
            //bool hasCharacter = phone.Any(char.IsLetter);
            bool hasCharacter = int.TryParse(phone, out int _);
            if (hasCharacter)
            {
                return $"Dialing... {phone}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
