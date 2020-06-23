using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();

        }
        public string Name { get; set; }
        public int Count => this.Roster.Count();
        public int Capacity { get; set; }
        public List<Player> Roster { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count < this.Capacity)
            {
                this.Roster.Add(player);

            }
        }

        public bool RemovePlayer(string name)
        {

            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Name == name)
                {
                    this.Roster.RemoveAt(i);

                    return true;


                }
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Name == name && this.Roster[i].Rank != "Member")
                {
                    this.Roster[i].Rank = "Member";

                }
            }

        }

        public void DemotePlayer(string name)
        {
            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Name == name && this.Roster[i].Rank != "Trial")
                {
                    this.Roster[i].Rank = "Trial";

                }
            }

        }

        public Player[] KickPlayersByClass(string className)
        {
            List<Player> result = new List<Player>();

            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Class == className)
                {
                    result.Add(this.Roster[i]);
                  
                }
            }

            this.Roster = this.Roster.Where(x => x.Class != className).ToList();

            return result.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.Roster)
            {
                sb.AppendLine(player.ToString());
            }


            return sb.ToString().Trim();
        }

       
    }
}
