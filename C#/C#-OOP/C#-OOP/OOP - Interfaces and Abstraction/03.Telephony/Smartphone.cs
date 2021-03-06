using System;
using System.Linq;
using System.Text;

namespace OOP___Interfaces_and_Abstraction
{
    public class Smartphone : ICalable, IBrowsable
    {
        public string Model { get; private set; }

        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Browse(string webSite)
        {
            bool hasDigit = webSite.Any(char.IsDigit);
            if (!hasDigit)
            {
                return $"Browsing: {webSite}!";
            }
            else
            {
                return "Invalid URL!";
            }
        }

        public string Call(string phone)
        {
            //bool hasCharacter = phone.Any(char.IsLetter);
            bool hasCharacter = int.TryParse(phone, out int _);
            if (hasCharacter)
            {
                return $"Calling... {phone}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
