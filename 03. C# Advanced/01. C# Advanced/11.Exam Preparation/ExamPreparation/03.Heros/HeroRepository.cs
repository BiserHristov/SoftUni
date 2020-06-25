using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.data.FirstOrDefault(x => x.Name == name);
            this.data.Remove(hero);
        }
        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();

            return hero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());

            }
            return sb.ToString().Trim();
        }
    }
}
