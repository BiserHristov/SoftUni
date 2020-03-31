using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_projects
{
    class Start
    {
        public static void Main()
        {

            int count = int.Parse(Console.ReadLine());

            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine().Split('-').ToList();
                string creatorName = line[0];
                string teamName = line[1];

                if (allTeams.Find(x => x.Name == teamName) != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (allTeams.Find(x => x.Members.Contains(creatorName)) != null)
                {

                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    Team team = new Team();
                    team.Name = teamName;
                    team.Members.Add(creatorName);
                    allTeams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }

            }

            string command = Console.ReadLine();
            while (command != "end of assignment")
            {
                string[] input = command.Split("->").ToArray();
                string member = input[0];
                string teamName = input[1];

                if (allTeams.Find(x => x.Name == teamName) == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");

                }
                else if (allTeams.Find(x => x.Members.Contains(member)) != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    allTeams.Find(x => x.Name == teamName).Members.Add(member);
                }

                command = Console.ReadLine();
            }

            List<string> zeroMemberTeam = allTeams
                .Where(x => x.Members.Count == 1)
                .OrderBy(x => x.Name)
                .Select(x => x.Name)
                .ToList();

            allTeams.RemoveAll(x => x.Members.Count == 1);
            allTeams = allTeams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            for (int i = 0; i < allTeams.Count(); i++)
            {
                Console.WriteLine($"{allTeams[i].Name}");

                for (int j = 0; j < allTeams[i].Members.Count(); j++)
                {
                    string creator = allTeams[i].Members[0];
                    if (j == 0)
                    {
                        Console.WriteLine($"- {allTeams[i].Members[j]}");
                    }
                    else
                    {
                        List<string> members = allTeams[i].Members.ToList();
                        members.Remove(creator);
                        List<string> sortedMembers = members.OrderBy(a => a).ToList();
                        for (int k = 0; k < sortedMembers.Count; k++)
                        {
                            Console.WriteLine($"-- {sortedMembers[k]}");

                        }

                        break;
                    }

                }
            }

            Console.WriteLine("Teams to disband:");
            for (int i = 0; i < zeroMemberTeam.Count(); i++)
            {
                Console.WriteLine($"{zeroMemberTeam[i]}");

            }

        }



    }

    class Team
    {
        public Team()
        {

            this.Members = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Members { get; set; }


    }
}

