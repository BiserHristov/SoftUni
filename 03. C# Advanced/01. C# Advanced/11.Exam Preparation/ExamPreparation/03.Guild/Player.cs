using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {

    


        public Player(string name, string className)
            : this(name, className, "Trial", "n/a")
        {

        }

        public Player(string name, string className, string rank, string description)
        {
            this.Name = name;
            this.Class = className;
            this.Rank = rank;
            this.Description = description;

        }


        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");
            return sb.ToString().Trim();

        }
    }
}
