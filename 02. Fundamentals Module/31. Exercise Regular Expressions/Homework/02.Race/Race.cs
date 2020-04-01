using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Race
    {
        static void Main()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            List<string> names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var name in names)
            {
                dict.Add(name, 0);
            }

            string line = Console.ReadLine();


            while (line != "end of race")
            {
                Regex regex = new Regex(@"([A-Za-z]+)");
                MatchCollection matches = regex.Matches(line);
                string currentName = string.Empty;
                int currentDistance = 0;

                foreach (Match letter in matches)
                {
                    currentName += letter;
                }


                regex = new Regex(@"([0-9])");
                matches = regex.Matches(line);

                foreach (Match digit in matches)
                {
                    currentDistance += int.Parse(digit.Value);
                }

                if (dict.ContainsKey(currentName))
                {
                    dict[currentName] += currentDistance;
                }


                line = Console.ReadLine();
            }

            dict = dict.OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            StringBuilder sb = new StringBuilder();
            List<string> keys = dict.Keys.ToList();

            for (int i = 1; i <= 3; i++)
            {
                string place = string.Empty;
                if (i==1)
                {
                    place = "1st";
                }
                else if (i == 2)
                {
                    place = "2nd";
                }
                else if (i==3)
                {
                    place = "3rd";
                }

                sb.AppendFormat($"{place} place: {keys[i - 1]}\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
