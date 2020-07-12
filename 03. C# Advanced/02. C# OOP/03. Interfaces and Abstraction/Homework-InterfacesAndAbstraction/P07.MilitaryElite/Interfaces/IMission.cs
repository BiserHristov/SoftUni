using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string Name { get; }
        States State { get; }
        void CompleteMission();
    }
}
