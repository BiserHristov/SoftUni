using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            //contest,password
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string line = Console.ReadLine();

            while (line != "end of contests")
            {
                string[] input = line
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string name = input[0];
                string password = input[1];

                if (!contests.ContainsKey(name))
                {
                    contests[name] = password;
                }

                line = Console.ReadLine();

            }
            //user<contest,points>
            Dictionary<string, Dictionary<string, decimal>> users = new Dictionary<string, Dictionary<string, decimal>>();
            line = Console.ReadLine();

            while (line != "end of submissions")
            {
                string[] input = line
               .Split("=>", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                string contest = input[0];
                string password = input[1];
                string username = input[2];
                decimal points = decimal.Parse(input[3]);

           
                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    line = Console.ReadLine();
                    continue;

                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, decimal>());
                }
                if (!users[username].ContainsKey(contest))
                {
                    users[username].Add(contest, points);
                }
                else
                {
                    if (points > users[username][contest])
                    {
                        users[username][contest] = points;
                    }
                }


                line = Console.ReadLine();

            }
  
            var person = users.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();
            Console.WriteLine($"Best candidate is {person.Key} with total {person.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            
            foreach (var uvp in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(uvp.Key);
                foreach (var cpp in uvp.Value.OrderByDescending(y => y.Value))
                {
                    Console.WriteLine($"#  {cpp.Key} -> {cpp.Value}");
                }
            }
        }
    }
}
