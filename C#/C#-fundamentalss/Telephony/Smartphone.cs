using System;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Model { get; private set; }

        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Browse(string webSite)
        {
            bool hasDigit = webSite.Any(char.IsDigit);
            if (hasDigit)
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {webSite}!";
            }
        }

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
                return $"Calling... {phone}";
            }
        }
    }
}
