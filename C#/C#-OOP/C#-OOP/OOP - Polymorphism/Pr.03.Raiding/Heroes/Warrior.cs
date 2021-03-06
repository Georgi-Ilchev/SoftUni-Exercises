using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Raiding.Heroes
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) : base(name)
        {
            this.Power = WarriorPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
