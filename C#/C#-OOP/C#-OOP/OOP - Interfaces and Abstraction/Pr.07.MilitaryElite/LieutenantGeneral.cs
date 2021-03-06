using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pr._07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }
        public List<Private> Privates
        {
            get => this.privates;
            private set => this.privates = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var privateSoldier in this.Privates)
            {
                sb.AppendLine("  " + privateSoldier.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
