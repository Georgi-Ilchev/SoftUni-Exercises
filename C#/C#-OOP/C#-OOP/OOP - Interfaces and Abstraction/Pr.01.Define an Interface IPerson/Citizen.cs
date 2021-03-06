using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._01.Define_an_Interface_IPerson
{
    public class Citizen : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
