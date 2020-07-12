using System.Collections.Generic;

namespace P07.MilitaryElite.Interfaces
{
    interface IEngineer: ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        void AddReapir(IRepair repair);
    }
}
