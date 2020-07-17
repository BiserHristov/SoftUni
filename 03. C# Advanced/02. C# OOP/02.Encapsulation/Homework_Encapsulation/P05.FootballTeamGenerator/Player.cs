using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Player
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;

        private string name;
        private Dictionary<string, int> validStats;
        public Player(string name)
        {
            this.validStats = new Dictionary<string, int>();
            LoadValidStats();
            this.Name = name;
        }
        //private double Level => this.ValidStats.Values.Average();
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

        public Dictionary<string, int> ValidStats
        {
            get
            {
                return this.validStats;
            }
        }

        private void LoadValidStats()
        {
            this.ValidStats.Add("endurance", 0);
            this.ValidStats.Add("sprint", 0);
            this.ValidStats.Add("dribble", 0);
            this.ValidStats.Add("passing", 0);
            this.ValidStats.Add("shooting", 0);
        }

        public void AddStats(int[] skills)
        {
            List<string> loadedSkills = this.ValidStats.Keys.ToList();


            for (int i = 0; i < loadedSkills.Count; i++)
            {
                if (!ValidateSkill(skills[i]))
                {
                    throw new ArgumentException($"{loadedSkills[i].First().ToString().ToUpper() + loadedSkills[i].Substring(1)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.ValidStats[loadedSkills[i]] = skills[i];
            }

        }
        private bool ValidateSkill(int skill)
        {
            if (skill < 0 || skill > 100)
            {
                return false;
            }

            return true;
        }


    }
}
