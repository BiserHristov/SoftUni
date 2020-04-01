using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            //name <health,damage>
            Dictionary<string, Dictionary<double, double>> demons = new Dictionary<string, Dictionary<double, double>>();

            for (int i = 0; i < input.Count; i++)
            {
                demons.Add(input[i], new Dictionary<double, double>());

                Regex regex = new Regex(@"[^0-9+\-*\/\.]");
                MatchCollection matches = regex.Matches(input[i]);
                double health = 0;
                double damage = 0;

                foreach (Match match in matches)
                {
                    health += (int)(char.Parse(match.Value));
                }

                regex = new Regex(@"[-]?\d+\.?(\d+)?");
                matches = regex.Matches(input[i]);

                foreach (Match number in matches)
                {
                    damage += double.Parse(number.Value);
                }

                regex = new Regex(@"[*\/]");
                matches = regex.Matches(input[i]);

                foreach (Match symbol in matches)
                {
                    if (symbol.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (symbol.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                demons[input[i]].Add(health, damage);


            }

            demons = demons
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            StringBuilder sb = new StringBuilder();

            foreach (var item in demons)
            {
                sb.AppendLine($"{item.Key} - {item.Value.Keys.ToArray().FirstOrDefault()} health, {item.Value.Values.ToArray().FirstOrDefault():F2} damage");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
