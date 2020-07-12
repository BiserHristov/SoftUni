using P07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string Name { get; }
        States State { get; }
        void CompleteMission();
    }
}
