using System.Collections.Generic;

namespace P07.MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);
    }
}
