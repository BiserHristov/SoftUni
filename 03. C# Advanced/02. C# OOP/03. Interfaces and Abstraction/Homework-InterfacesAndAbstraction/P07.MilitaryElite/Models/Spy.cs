using P07.MilitaryElite.Interfaces;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastname, int codeNumber)
            : base(id, firstName, lastname)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().Trim();
        }
    }
}
