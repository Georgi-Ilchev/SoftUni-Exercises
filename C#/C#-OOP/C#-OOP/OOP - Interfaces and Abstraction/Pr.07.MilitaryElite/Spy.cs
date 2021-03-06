using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._07.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public Spy(string id, string firstName, string lastName, int codeNum)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNum;
        }
        public int CodeNumber
        {
            get => this.codeNumber;
            private set => this.codeNumber = value;
        }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id>
            //Code Number: < codeNumber >

            return base.ToString() + $"\nCode Number: {this.CodeNumber}";
        }
    }
}
