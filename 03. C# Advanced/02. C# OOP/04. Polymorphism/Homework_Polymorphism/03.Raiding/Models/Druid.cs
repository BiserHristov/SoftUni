namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int DEFAULT_POWER = 80;
        public Druid(string name) : base(name, DEFAULT_POWER)
        {
        }
        public override string CastAbility()
        {
            return string.Format(base.CastAbility(), this.GetType().Name, this.Name, "healed", this.Power);
        }
    }
}
