using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Interfaces
{
    interface IEngineer: ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        void AddReapir(IRepair repair);
    }
}
