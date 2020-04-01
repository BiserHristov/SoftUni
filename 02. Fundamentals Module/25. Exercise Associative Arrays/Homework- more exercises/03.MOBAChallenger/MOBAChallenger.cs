using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> playerPositionSkill = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                List<string> line = input
                             .Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries)
                             .ToList();

                if (line.Count == 3)
                {
                    string name = line[0];
                    string position = line[1];
                    int skill = int.Parse(line[2]);

                    if (!playerPositionSkill.ContainsKey(name))
                    {
                        playerPositionSkill.Add(name, new Dictionary<string, int>());

                    }
                    if (!playerPositionSkill[name].ContainsKey(position))
                    {
                        //check SKILL instead 0
                        playerPositionSkill[name].Add(position, 0);
                    }
                    if (skill > playerPositionSkill[name][position])
                    {
                        playerPositionSkill[name][position] = skill;
                    }
                }
                else if (line.Count == 2)
                {
                    string firstPlayer = line[0];
                    string secondPlayer = line[1];

                    if (playerPositionSkill.ContainsKey(firstPlayer)
                        && playerPositionSkill.ContainsKey(secondPlayer))
                    {

                        List<string> firstPlayerPositions = playerPositionSkill[firstPlayer].Keys.ToList();
                        List<string> secondPlayerPositions = playerPositionSkill[secondPlayer].Keys.ToList();
                        List<string> commonPositions = firstPlayerPositions.Intersect(secondPlayerPositions).ToList();
                        if (commonPositions.Count > 0)
                        {
                            if (playerPositionSkill[firstPlayer].Values.Sum() > playerPositionSkill[secondPlayer].Values.Sum())
                            {
                                playerPositionSkill.Remove(secondPlayer);
                            }
                            else if (playerPositionSkill[secondPlayer].Values.Sum() > playerPositionSkill[firstPlayer].Values.Sum())
                            {
                                playerPositionSkill.Remove(firstPlayer);
                            }

                        }
                    }



                }

                input = Console.ReadLine();
            }


            playerPositionSkill = playerPositionSkill
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var player in playerPositionSkill)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                var orderedInnerDictionary = player.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var psv in orderedInnerDictionary)
                {
                    Console.WriteLine($"- {psv.Key} <::> {psv.Value}");
                }
            }


        }
    }
}
