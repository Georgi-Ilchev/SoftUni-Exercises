using System;
using System.Collections.Generic;
using System.Text;

namespace testing.Heroes
{
    public class Paladin : BaseHero
    {
        private const int paladinPower = 100;
        public Paladin(string name) : base(name)
        {
            this.Power = paladinPower;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
