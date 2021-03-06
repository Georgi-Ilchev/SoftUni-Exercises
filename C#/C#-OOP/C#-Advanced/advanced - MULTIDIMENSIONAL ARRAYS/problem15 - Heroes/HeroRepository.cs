using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem15___Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count
        {
            get{ return this.data.Count; }
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(Hero name)
        {
            this.data.Remove(name);
        }
        public Hero GetHeroWithHighestStrength()
        {
            Hero currentHero = data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();
            return currentHero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            Hero currentHero = data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();
            return currentHero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            Hero currentHero = data.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();
            return currentHero;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Hero item in data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
