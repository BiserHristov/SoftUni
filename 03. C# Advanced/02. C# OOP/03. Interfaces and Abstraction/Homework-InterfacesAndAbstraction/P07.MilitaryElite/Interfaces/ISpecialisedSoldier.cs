using P07.MilitaryElite.Enumrations;

namespace P07.MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
