using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Animals.v2
{
    public class Frog : Animals
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}