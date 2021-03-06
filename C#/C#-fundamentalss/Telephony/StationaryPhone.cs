using System;
using System.Linq;
using System.Text;

namespace Telephony
{
    class StationaryPhone : ICallable
    {
        public string Call(string phone)
        {
            //bool hasCharacter = phone.Any(char.IsLetter);
            bool hasCharacter = int.TryParse(phone, out int _);
            if (!hasCharacter)
            {
                return "Invalid number!";
            }
            else
            {
               return $"Dialing... {phone}";
            }
        }
    }
}
