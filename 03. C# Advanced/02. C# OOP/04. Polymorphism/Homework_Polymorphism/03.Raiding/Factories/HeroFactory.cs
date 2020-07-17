using Raiding.Exceptions;
using Raiding.Models;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public Hero ProduceHero(string name, string type)
        {
            Hero hero = null;

            if (type=="Druid")
            {
                hero = new Druid(name);

            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);

            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);

            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);

            }


            if (hero!=null)
            {
                return hero;
            }
            else
            {
                throw new InvalidHeroTypeException();
            }
        }
    }
}
