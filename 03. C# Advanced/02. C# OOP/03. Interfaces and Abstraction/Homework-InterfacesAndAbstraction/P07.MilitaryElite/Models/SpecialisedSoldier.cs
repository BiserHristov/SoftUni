using P07.MilitaryElite.Enumrations;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.Interfaces;
using System;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastname, decimal salary, string corps)
            : base(id, firstName, lastname, salary)
        {
            this.Corps = ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps ParseCorps(string corpsString)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsString, false, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            return sb.ToString().Trim();
        }
    }
}
