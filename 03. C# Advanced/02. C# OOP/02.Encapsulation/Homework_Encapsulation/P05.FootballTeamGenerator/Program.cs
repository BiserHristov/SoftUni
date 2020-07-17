using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            while (input[0] != "END")
            {
                try
                {
                    string command = input[0];
                    string teamName = input[1];
                    Team team = FindTeam(teamName, teams);

                    if (command == "Add")
                    {
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = input[2];
                        int[] playerSkills = new int[5];

                        for (int i = 3; i < input.Length; i++)
                        {
                            playerSkills[i - 3] = int.Parse(input[i]);
                        }

                        Player player = new Player(playerName);
                        player.AddStats(playerSkills);
                        team.AddPlayer(player);

                    }
                    else if (command == "Remove")
                    {
                        team.RemovePlayer(input[2]);
                    }
                    else if (command == "Team")
                    {
                        Team newTeam = new Team(teamName);
                        teams.Add(newTeam);

                    }
                    else if (command == "Rating")
                    {
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        //foreach (var currentTeam in teams)
                        //{
                        sb.AppendLine(team.ToString());
                        //}
                    }

                   
                }
                catch (ArgumentException ex)
                {
                   sb.AppendLine(ex.Message);
                    
                }

                input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine(sb.ToString().Trim());

        }

        private static Team FindTeam(string teamName, List<Team> teams)
        {
            return teams.Where(x => x.Name == teamName).FirstOrDefault();

        }
    }
}
