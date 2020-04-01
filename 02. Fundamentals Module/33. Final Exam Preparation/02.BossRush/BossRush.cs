using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    class BossRush
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    sb.AppendLine($"{match.Groups["name"].Value}, The {match.Groups["title"].Value}");
                    sb.AppendLine($">> Strength: {match.Groups["name"].Value.Length}");
                    sb.AppendLine($">> Armour: {match.Groups["title"].Value.Length}");
                }
                else
                {
                    sb.AppendLine("Access denied!");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
