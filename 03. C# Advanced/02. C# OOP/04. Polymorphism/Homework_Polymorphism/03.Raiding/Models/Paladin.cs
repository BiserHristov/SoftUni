namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int DEFAULT_POWER = 100;
        public Paladin(string name) : base(name, DEFAULT_POWER)
        {
        }

        public override string CastAbility()
        {
            return string.Format(base.CastAbility(), this.GetType().Name, this.Name, "healed", this.Power);
        }
    }
}
