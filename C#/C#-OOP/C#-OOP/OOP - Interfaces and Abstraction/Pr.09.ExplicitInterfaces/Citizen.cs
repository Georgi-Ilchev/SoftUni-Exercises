using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Pr._09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; }

        public string Country { get; }

        public int Age { get; }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }
        void IPerson.GetName()
        {
            Console.WriteLine($"{this.Name}");
        }
    }
}
