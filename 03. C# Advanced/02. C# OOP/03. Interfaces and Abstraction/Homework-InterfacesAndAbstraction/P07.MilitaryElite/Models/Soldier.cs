using P07.MilitaryElite.Interfaces;

namespace P07.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastname)
        {
            this.Id = id;
            this.Firstname = firstName;
            this.LastName = lastname;
        }
        public int Id { get; private set; }

        public string Firstname { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.Firstname} {this.LastName} Id: {Id}";
        }
    }
}
