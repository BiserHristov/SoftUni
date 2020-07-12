using P07.MilitaryElite.Interfaces;

namespace P07.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string name, int hoursWorked)
        {
            this.Name = name;
            this.HoursWorked = hoursWorked;
        }

        public string Name { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
