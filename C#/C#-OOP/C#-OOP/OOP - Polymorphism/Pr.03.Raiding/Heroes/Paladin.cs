using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Raiding.Heroes
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;
        public Paladin(string name) : base(name)
        {
            this.Power = PaladinPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
