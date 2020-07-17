namespace Raiding.Interfaces
{
    interface IHero
    {
        string Name { get; }
        public int Power { get; }
        string CastAbility();
    }
}
