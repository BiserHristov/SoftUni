using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays_More_Exercise
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                List<string> line = input.Split(':', StringSplitOptions.RemoveEmptyEntries).ToList();
                string contest = line[0];
                string password = line[1];

                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword[contest] = password;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            //Dictionary<string, List<string>> userContests = new Dictionary<string, List<string>>();

            while (input != "end of submissions")
            {
                List<string> line = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToList();
                string contest = line[0];
                string password = line[1];
                string userName = line[2];
                int points = int.Parse(line[3]);

                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (!dict.ContainsKey(userName))
                    {
                        dict.Add(userName, new Dictionary<string, int>());
                        dict[userName].Add(contest, points);

                    }
                    else
                    {
                        if (!dict[userName].ContainsKey(contest))
                        {
                            dict[userName].Add(contest, points);
                        }
                        else
                        {
                            if (points > dict[userName][contest])
                            {

                                dict[userName][contest] = points;
                            }
                        }
                    }

                }


                input = Console.ReadLine();
            }

            int maxSum = 0;

            Dictionary<string, int> userMaxPoints = new Dictionary<string, int>();

            //int maxSum = dict.Values.Select(x => x.Values.Sum()).ToList().Max();
            

            foreach (var user in dict)
            {
                int currentSum = user.Value.Values.Sum();


                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

            }


            foreach (var user in dict)
            {
                if (user.Value.Values.Sum() == maxSum)
                {
                    userMaxPoints.Add(user.Key, maxSum);
                }
            }


            foreach (var user in userMaxPoints)
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value} points.");
            }

            dict = dict
                .OrderBy(x => x.Key)
                .ThenByDescending(x => x.Value.Select(v => v.Value))
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Ranking: ");
            foreach (var user in dict)
            {
                Console.WriteLine(user.Key);

                foreach (var cpp in user.Value.OrderByDescending(x => x.Value))
                {

                    Console.WriteLine($"#  {cpp.Key} -> {cpp.Value}");
                }
            }
        }
    }
}
