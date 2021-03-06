using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }
        public List<Repair> Repairs
        {
            get => this.repairs;
            private set => this.repairs = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
