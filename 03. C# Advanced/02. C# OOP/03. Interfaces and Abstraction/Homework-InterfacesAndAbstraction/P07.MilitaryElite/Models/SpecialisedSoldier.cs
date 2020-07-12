using P07.MilitaryElite.Enumrations;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastname, decimal salary, string corps)
            : base(id, firstName, lastname, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; set; }

        private void ParseCorps(string corpsString)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsString, out corps);

            if (!parsed)
            {
                throw new ArgumentException(string.Format(CommonExceptions.NotValidCorpsMessage, corpsString));
            }

            this.Corps = corps;
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
