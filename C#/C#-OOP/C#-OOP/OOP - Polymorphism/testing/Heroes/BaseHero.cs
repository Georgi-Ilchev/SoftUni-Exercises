using System;
using System.Collections.Generic;
using System.Text;

namespace testing.Heroes
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public int Power
        {
            get => this.power;
            set => this.power = value;
        }
        public abstract string CastAbility();
    }
}
