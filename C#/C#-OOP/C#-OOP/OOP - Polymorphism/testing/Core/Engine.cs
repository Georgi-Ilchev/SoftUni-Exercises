using System;
using System.Collections.Generic;
using System.Text;
using testing.Core.Contracts;
using testing.Heroes;
using testing.IO;
using testing.IO.Contracts;

namespace testing.Core
{
    public class Engine : IEngine
    {
        public IReader reader;
        public IWriter writer;
        public List<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            var reader = new ConsoleReader();
            int n = int.Parse(Console.ReadLine());

            while (n != this.heroes.Count)
            {
                var name = reader.Read();
                var type = reader.Read();
                var createHero = new CreateHero();

                try
                {
                    var hero = createHero.Create(name, type);
                    this.heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int bossPower = int.Parse(reader.Read());
            string raidResult = BossFight(bossPower);
            ConsoleWriter writer = new ConsoleWriter();
            writer.Write(raidResult);
        }

        public string BossFight(int bossPower)
        {
            ConsoleWriter writer = new ConsoleWriter();
            int raidPower = 0;

            foreach (var hero in this.heroes)
            {
                writer.Write(hero.CastAbility());
                raidPower += hero.Power;
            }
            string result = bossPower <= raidPower ? "Victory!" : "Defeat...";
            return result;
                
        }
    }
}
