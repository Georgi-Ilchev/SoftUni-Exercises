using System;
using System.Collections.Generic;
using System.Text;

namespace testing.Heroes
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;
        public Warrior(string name) : base(name)
        {
            this.Power = warriorPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
