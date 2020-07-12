using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                string command = input[0];

                if (command == "Add")
                {
                    bool isPresent = false;

                    foreach (var addTeam in teams)
                    {
                        if (addTeam.Name == input[1])
                        {
                            isPresent = true;
                            break;
                        }

                    }

                    if (!isPresent)
                    {
                        throw new ArgumentException($"Team {input[1]} does not exist.");
                    }

                    string playerName = input[2];
                    int[] playerSkills = new int[5];

                    for (int i = 3; i < input.Length; i++)
                    {
                        playerSkills[i - 3] = int.Parse(input[i]);
                    }

                    Player player = new Player(playerName);
                    player.AddStats(playerSkills);
                    Team team = teams.Where(x => x.Name == input[1]).FirstOrDefault();
                    team.AddPlayer(player);

                }
                else if (command == "Remove")
                {
                    bool isPresent = false;

                    foreach (var curTeam in teams)
                    {
                        if (curTeam.Name == input[1])
                        {
                            isPresent = true;
                            break;
                        }

                    }

                    if (!isPresent)
                    {
                        throw new ArgumentException($"Team {input[1]} does not exist.");
                    }

                    Team team = teams.Where(x => x.Name == input[1]).FirstOrDefault();

                    team.RemovePlayer(input[2]);
                }
                else if (command == "Team")
                {
                    Team team = new Team(input[1]);
                    teams.Add(team);

                }
                else if (command == "Rating")
                {
                    bool isPresent = false;

                    foreach (var curTeam in teams)
                    {
                        if (curTeam.Name == input[1])
                        {
                            isPresent = true;
                            break;
                        }

                    }

                    if (!isPresent)
                    {
                        throw new ArgumentException($"Team {input[1]} does not exist.");
                    }
                    foreach (var team in teams)
                    {
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
