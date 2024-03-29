﻿using P07.MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastname, decimal salary)
            : base(id, firstName, lastname, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates =>(IReadOnlyCollection<IPrivate>) this.privates;
        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in this.privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            return sb.ToString().Trim();

        }
    }
}
