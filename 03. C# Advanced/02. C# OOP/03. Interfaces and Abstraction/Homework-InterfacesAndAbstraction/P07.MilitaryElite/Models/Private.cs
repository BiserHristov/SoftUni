using P07.MilitaryElite.Interfaces;

namespace P07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastname, decimal salary)
            : base(id, firstName, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {

            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}
