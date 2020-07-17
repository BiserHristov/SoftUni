namespace Raiding.Models
{
    public class Rogue : Hero
    {
        private const int DEFAULT_POWER = 80;

        public Rogue(string name) : base(name, DEFAULT_POWER)
        {
        }
        public override string CastAbility()
        {
            return string.Format(base.CastAbility(), this.GetType().Name, this.Name, "hit", this.Power) + " damage";
        }
    }
}
