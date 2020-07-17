namespace Raiding.Models
{
    public class Warrior : Hero
    {
        private const int DEFAULT_POWER = 100;

        public Warrior(string name) : base(name, DEFAULT_POWER)
        {
        }
        public override string CastAbility()
        {
            return string.Format(base.CastAbility(), this.GetType().Name, this.Name, "hit", this.Power) + " damage";
        }
    }
}
