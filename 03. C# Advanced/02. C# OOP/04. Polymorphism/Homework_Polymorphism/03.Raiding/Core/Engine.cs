using Raiding.Core.Interfaces;
using Raiding.Exceptions;
using Raiding.Factories;
using Raiding.Interfaces;
using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private HeroFactory factory;
        private ICollection<IHero> heroes;
        public Engine()
        {
            this.factory = new HeroFactory();
            this.heroes = new List<IHero>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            int count = int.Parse(this.reader.ReadLine());

            while (this.heroes.Count != count)
            {
                try
                {
                    string name = this.reader.ReadLine();
                    string type = this.reader.ReadLine();
                    this.heroes.Add(this.factory.ProduceHero(name, type));
                }
                catch (InvalidHeroTypeException ihte)
                {
                    this.writer.Write(ihte.Message);
                }
            }




            int bossPower = int.Parse(Console.ReadLine());

            int herosPower = 0;

            foreach (var hero in heroes)
            {
                this.writer.Write(hero.CastAbility());
                herosPower += hero.Power;
            }

            if (herosPower >= bossPower)
            {
                this.writer.Write("Victory!");
            }
            else
            {
                this.writer.Write("Defeat...");
            }
        }
    }

}
