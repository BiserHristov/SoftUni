using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;

        private string name;


        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A {nameof(Name)} should not be empty.");

                }

                this.name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                double result = 0;

                foreach (var player in players)
                {
                    result += (player.ValidStats.Values.Sum()) / 5.0;
                }

                return (int)Math.Round(result);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);

        }
        public void RemovePlayer(string playerName)
        {
            Player searchedPlayer = this.players.Where(x => x.Name == playerName).FirstOrDefault();

            if (searchedPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(searchedPlayer);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
