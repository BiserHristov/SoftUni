using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class StarEnigma
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            dict.Add("Attacked", new List<string>());
            dict.Add("Destroyed", new List<string>());

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                List<char> list = new List<char>() { 's', 't', 'a', 'r' };
                string letters = @"[star]";



                int lettersCount = Regex.Matches(line.ToLower(), letters).Count;
                string result = string.Empty;
                for (int j = 0; j < line.Length; j++)
                {

                    result += (char)(line[j] - lettersCount);

                }

                string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*?:(?<population>\-?\d+)[^@\-!:>]*?!(?<action>A|D)![^@\-!:>]*?\->(?<soldierCount>\-?\d+)";
                Match match = Regex.Match(result, pattern);

                if (match.Success)
                {

                    if (match.Groups["action"].Value == 'A'.ToString())
                    {
                        dict["Attacked"].Add(match.Groups["planet"].Value);

                    }
                    else if (match.Groups["action"].Value == 'D'.ToString())
                    {
                        dict["Destroyed"].Add(match.Groups["planet"].Value);

                    }
                }




            }

            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Attacked planets: {dict["Attacked"].Count()}");
            if (dict["Attacked"].Count > 0)
            {
                dict["Attacked"].Sort();

                foreach (var planet in dict["Attacked"])
                {
                    sb.AppendLine($"-> {planet}");
                }
            }

            sb.AppendLine($"Destroyed planets: {dict["Destroyed"].Count()}");
            if (dict["Destroyed"].Count > 0)
            {
                dict["Destroyed"].Sort();

                foreach (var planet in dict["Destroyed"])
                {
                    sb.AppendLine($"-> {planet}");
                }
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
