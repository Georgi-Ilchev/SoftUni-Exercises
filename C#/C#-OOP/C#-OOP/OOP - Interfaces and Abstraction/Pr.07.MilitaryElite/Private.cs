using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._07.MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public Private(string id, string firstName, string lastName, decimal salary)
            :base (id,firstName,lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary
        {
            get => this.salary;
            private set => this.salary = value;
        }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id> Salary: <salary>
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}
