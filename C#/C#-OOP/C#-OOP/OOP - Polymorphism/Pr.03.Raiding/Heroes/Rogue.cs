using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Raiding.Heroes
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) : base(name)
        {
            this.Power = RoguePower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
