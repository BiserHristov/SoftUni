using Raiding.Interfaces;

namespace Raiding.Models
{
    public abstract class Hero : IHero
    {

        public Hero(string name, int power)
        {

            this.Name = name;
            this.Power = power;
        }



        public int Power { get; private set; }
        public string Name { get; private set; }


        public virtual string CastAbility()
        {
            return "{0} - {1} {2} for {3}";
        }



        //private HeroType ParseHeroType(string input)
        //{
        //    HeroType type;
        //    bool parsed = Enum.TryParse<HeroType>(input, false, out type);

        //    if (!parsed)
        //    {
        //        throw new InvalidHeroTypeException();
        //    }

        //    return type;

        //}
    }
}
