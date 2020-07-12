using P07.MilitaryElite.Enumrations;

using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
